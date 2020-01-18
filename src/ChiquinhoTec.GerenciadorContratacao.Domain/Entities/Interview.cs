using System;
using ChiquinhoTec.GerenciadorContratacao.Common;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the entity. ///
    //    
    public class Interview : BaseEntity
    {
        public Interview() { }

        public Interview(DateTime schedulingDate, string squad, Person person)
        {
            SchedulingDate = SchedulingDate;
            Squad = squad;
            Person = person;
        }

        public DateTime SchedulingDate { get; private set; }

        public string Squad { get; private set; }

        public Person Person { get; private set; }
    }
}