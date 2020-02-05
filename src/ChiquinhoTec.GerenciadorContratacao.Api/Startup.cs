using AutoMapper;
using ChiquinhoTec.GerenciadorContratacao.Api.Middlewares;
using ChiquinhoTec.GerenciadorContratacao.Infra.Data;
using ChiquinhoTec.GerenciadorContratacao.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Globalization;

namespace ChiquinhoTec.GerenciadorContratacao.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        private const string AllowAllCors = "AllowAll";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(Configuration);

            InjectorBootStrapper.RegisterServices(services, Configuration);

            services.AddControllers();

            services.AddHealthChecks();
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddAutoMapper(typeof(MappingProfile));

            string mongoUri = Configuration["MongoConfiguration:Uri"];

            services.AddCors(options =>
            {
                options.AddPolicy(AllowAllCors,
                    builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                    });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://jacksonveroneze.auth0.com/";
                options.Audience = "https://jacksonveroneze.azurewebsites.net";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("create:address", policy => policy.Requirements.Add(new HasScopeRequirement("create:address", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("create:interview", policy => policy.Requirements.Add(new HasScopeRequirement("create:interview", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("create:person", policy => policy.Requirements.Add(new HasScopeRequirement("create:person", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("read:address", policy => policy.Requirements.Add(new HasScopeRequirement("read:address", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("read:interview", policy => policy.Requirements.Add(new HasScopeRequirement("read:interview", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("read:person", policy => policy.Requirements.Add(new HasScopeRequirement("read:person", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("read:person-address", policy => policy.Requirements.Add(new HasScopeRequirement("read:person", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("read:person-interview", policy => policy.Requirements.Add(new HasScopeRequirement("read:person", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("remove:address", policy => policy.Requirements.Add(new HasScopeRequirement("remove:address", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("remove:interview", policy => policy.Requirements.Add(new HasScopeRequirement("remove:interview", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("remove:perso", policy => policy.Requirements.Add(new HasScopeRequirement("remove:perso", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("update:address", policy => policy.Requirements.Add(new HasScopeRequirement("update:address", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("update:interview", policy => policy.Requirements.Add(new HasScopeRequirement("update:interview", "https://jacksonveroneze.auth0.com/")));
                options.AddPolicy("update:person", policy => policy.Requirements.Add(new HasScopeRequirement("update:person", "https://jacksonveroneze.auth0.com/")));
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
                //app.UseDeveloperExceptionPage();
   
            app.UseSerilogRequestLogging();

            CultureInfo[] supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseCors(AllowAllCors);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseHealthChecks("/check");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<GraphQLMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}