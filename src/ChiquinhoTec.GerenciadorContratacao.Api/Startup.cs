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
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Globalization;

namespace ChiquinhoTec.GerenciadorContratacao.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string AllowAllCors = "AllowAll";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(Configuration);

            InjectorBootStrapper.RegisterServices(services, Configuration);

            services.AddControllers();

            services.AddHealthChecks();
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddAutoMapper(typeof(MappingProfile));

            string mongoUri = Configuration["MongoConfiguration:Uri"];

            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .MinimumLevel.Override("System", LogEventLevel.Information)
                    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate)
                    .Enrich.FromLogContext()
                    //.WriteTo.MongoDB(mongoUri, collectionName: "applog")
                    .CreateLogger();

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
                options.AddPolicy("read:person", policy => policy.Requirements.Add(new HasScopeRequirement("read:person", "https://jacksonveroneze.auth0.com/")));
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            CultureInfo[] supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            loggerFactory.AddSerilog();

            //app.UseRequestResponseLogging();

            app.UseCors(AllowAllCors);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseHealthChecks("/check");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
