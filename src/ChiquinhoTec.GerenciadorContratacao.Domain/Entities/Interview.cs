using System;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Enums;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the entity. ///
    //    
    public class Interview : BaseEntity
    {
        public Interview() { }

        public Interview(DateTime schedulingDate, Squads squad, Person person)
        {
            SchedulingDate = schedulingDate;
            Squad = squad;
            Person = person;
        }

        public DateTime SchedulingDate { get; private set; }

        public Squads Squad { get; private set; }

        public virtual Person Person { get; private set; }

        public void Update(DateTime schedulingDate, Squads squad)
        {
            SchedulingDate = schedulingDate;
            Squad = squad;
        }
    }
}