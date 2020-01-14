using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Cep { get; private set; }

        public string Estado { get; private set; }

        public string Cidade { get; private set; }

        public string Bairro { get; private set; }

        public string Rua { get; private set; }

        public int Numero { get; private set; }

        public string Complemento { get; private set; }

        public bool EnderecoPrincipal { get; private set; }

        public Pessoa Pessoa { get; private set; }
    }
}