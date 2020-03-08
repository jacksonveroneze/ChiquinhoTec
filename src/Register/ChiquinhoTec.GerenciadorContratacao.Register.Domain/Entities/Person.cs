using System;
using System.Collections.Generic;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.ValueObjects;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the entity. ///
    //    
    public class Person : BaseEntity
    {
        public Person() {}

        public Person(string name, DateTime birthDate, Cpf cpf, string phone, Email email, string profile, string professionalDescription) : base()
        {
            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
            Phone = phone;
            Email = email;
            Profile = profile;
            ProfessionalDescription = professionalDescription;
        }

        public string Name { get; private set; }

        public DateTime BirthDate { get; private set; }

        public virtual Cpf Cpf { get; private set; }

        public string Phone { get; private set; }

        public virtual Email Email { get; private set; }

        public string Profile { get; private set; }

        public string ProfessionalDescription { get; private set; }

        public virtual IEnumerable<Address> Adresses { get; private set; } = new List<Address>();

        public void Update(string name, DateTime birthDate, Cpf cpf, string phone, Email email, string profile, string professionalDescription)
        {
            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
            Phone = phone;
            Email = email;
            Profile = profile;
            ProfessionalDescription = professionalDescription;
        }
    }
}