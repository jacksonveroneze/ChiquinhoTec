using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    public class Entrevista : BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public TimeSpan Hora { get; set; }

        public string Squad { get; set; }

        public Guid Pessoa { get; set; }
    }
}