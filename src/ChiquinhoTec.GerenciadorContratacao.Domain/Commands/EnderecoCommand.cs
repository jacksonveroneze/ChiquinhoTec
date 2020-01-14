using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    public class EnderecoCommand : BaseCommand
    {
        public Guid Id { get; set; }

        public string Cep { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Rua { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        public bool EnderecoPrincipal { get; set; }

        public Guid Pessoa { get; set; }
    }
}