using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    public class Entrevista : BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime Data { get; private set; }

        public TimeSpan Hora { get; private set; }

        public string Squad { get; private set; }

        public Pessoa Pessoa { get; private set; }
    }
}