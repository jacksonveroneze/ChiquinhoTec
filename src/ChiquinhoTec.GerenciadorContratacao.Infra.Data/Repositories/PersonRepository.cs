using System.Linq;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Repositories
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

        public async Task<Person> FindPersonByCpfAsync(string value)
        {
            return await _context
                    .Set<Person>()
                    .Where(x => x.Cpf.Value == value)
                    .FirstOrDefaultAsync();
        }

        public async Task<Person> FindPersonByEmailAsync(string value)
        {
            return await _context
                    .Set<Person>()
                    .Where(x => x.Email.Value == value)
                    .FirstOrDefaultAsync();
        }
    }
}