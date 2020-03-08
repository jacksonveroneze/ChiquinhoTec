using ChiquinhoTec.GerenciadorContratacao.Common;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Domain.Results
{
    //
    // Summary:
    //     /// Class responsible for the command. ///
    //
    public class CepResult : BaseCommand
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Localidade { get; set; }

        public string Uf { get; set; }

        public string Unidade { get; set; }

        public string Ibge { get; set; }

        public string Gia { get; set; }
    }
}