using ChiquinhoTec.GerenciadorContratacao.Common;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Domain.Commands
{
    //
    // Summary:
    //     /// Class responsible for the command. ///
    //
    public class PersonFilterCommand : BaseCommand
    {
        public string City { get; set; }

        public string State { get; set; }

        public string Email { get; set; }
    }
}