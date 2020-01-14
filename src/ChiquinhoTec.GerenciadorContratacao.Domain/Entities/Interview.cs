using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the entity. ///
    //    
    public class Interview : BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime Date { get; private set; }

        public TimeSpan Schedule { get; private set; }

        public string Squad { get; private set; }

        public Person Person { get; private set; }
    }
}