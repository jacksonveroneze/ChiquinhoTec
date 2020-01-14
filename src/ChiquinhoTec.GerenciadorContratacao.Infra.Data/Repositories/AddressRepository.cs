using System;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.AddressRepository
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