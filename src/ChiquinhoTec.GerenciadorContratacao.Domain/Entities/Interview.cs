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
        public DateTime Date { get; private set; }

        public TimeSpan Schedule { get; private set; }

        public string Squad { get; private set; }

        public Person Person { get; private set; }
    }
}