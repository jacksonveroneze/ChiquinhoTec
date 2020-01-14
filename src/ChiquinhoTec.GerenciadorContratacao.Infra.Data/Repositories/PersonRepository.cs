using System;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.PersonRepository
{
    //
    // Summary:
    //     /// Class responsible for the repository. ///
    //
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        //
        // Summary:
        //     /// Method responsible for initializing the repository. ///
        //
        // Parameters:
        //   context:
        //     The context param.
        //
        public PersonRepository(ApplicationDbContext context) : base(context) { }
    }
}