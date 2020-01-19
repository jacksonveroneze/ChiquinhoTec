﻿using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using ChiquinhoTec.GerenciadorContratacao.Infra.Data.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Services;
using ChiquinhoTec.GerenciadorContratacao.Services.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChiquinhoTec.GerenciadorContratacao.IoC
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration Configuration)
        {
            //
            // Inject Services
            //
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IInterviewService, InterviewService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IEntityAuditService, EntityAuditService>();
            //
            // Inject Repositories
            //
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IInterviewRepository, InterviewRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IEntityAuditRepository, EntityAuditRepository>();
            //
            // Inject Validators
            //
            services.AddTransient<IValidator<AddressCommand>>(x => new AddressValidator(x.GetRequiredService<IPersonRepository>()));
            services.AddTransient<IValidator<InterviewCommand>>(x => new InterviewValidator(x.GetRequiredService<IPersonRepository>(), x.GetRequiredService<IInterviewRepository>()));
            services.AddTransient<IValidator<PersonCommand>>(x => new PersonValidator(x.GetRequiredService<IPersonRepository>()));
        }
    }
}