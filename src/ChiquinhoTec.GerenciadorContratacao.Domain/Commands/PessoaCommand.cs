using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Perfil { get; set; }

        public string DescricaoProfissional { get; set; }
    }
}