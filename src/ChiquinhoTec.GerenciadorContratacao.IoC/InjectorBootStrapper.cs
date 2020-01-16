using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using ChiquinhoTec.GerenciadorContratacao.Infra.Data;
using ChiquinhoTec.GerenciadorContratacao.Infra.Data.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Services;
using ChiquinhoTec.GerenciadorContratacao.Services.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChiquinhoTec.GerenciadorContratacao.IoC
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            //// Add DbContext using SQL Server Provider
            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseNpgsql(Configuration.GetConnectionString("PharmacyConnection"));
            //    //options.EnableSensitiveDataLogging();
            //});
            //
            // Inject Services
            //
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IInterviewService, InterviewService>();
            services.AddTransient<IPersonService, PersonService>();

            //
            // Inject Repositories
            //
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IInterviewRepository, InterviewRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            //
            services.AddTransient<IValidator<PersonCommand>, PersonValidator>();
        }
    }
}