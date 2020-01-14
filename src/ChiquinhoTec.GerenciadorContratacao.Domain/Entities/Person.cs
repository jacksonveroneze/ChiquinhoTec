using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the entity. ///
    //    
    public class Pessoa : BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Nome { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public Cpf Cpf { get; private set; }

        public string Telefone { get; private set; }

        public Email Email { get; private set; }

        public string Perfil { get; private set; }

        public string DescricaoProfissional { get; private set; }

        public virtual IEnumerable<Endereco> Enderecos { get; private set; } = new List<Endereco>();

        public virtual IEnumerable<Entrevista> Entrevistas { get; private set; } = new List<Entrevista>();
    }
}