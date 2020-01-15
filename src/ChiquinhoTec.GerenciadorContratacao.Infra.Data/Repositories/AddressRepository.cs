using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Repositories
{
    //
    // Summary:
    //     /// Class responsible for the repository. ///
    //
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        //
        // Summary:
        //     /// Method responsible for initializing the repository. ///
        //
        // Parameters:
        //   context:
        //     The context param.
        //
        public AddressRepository(ApplicationDbContext context) : base(context) { }
    }
}