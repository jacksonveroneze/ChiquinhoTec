using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Commands;
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

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        public Task<List<Person>> FindByFilterAsync(PersonFilterCommand command)
        {
            return _context.Set<Person>()
                  .Select(p => p)
                  .Where(p => EF.Functions.ILike(p.Email.Value, @$"%{command.Email}%") ||
                                     p.Adresses.Any(x =>
                                            EF.Functions.ILike(x.State, @$"%{command.State}%") ||
                                            EF.Functions.ILike(x.City, @$"%{command.City}%")
                                     )
                               )
                  .AsNoTracking()
                  .ToListAsync();
        }

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public Task<Person> FindPersonByCpfAsync(string value)
        {
            return _context
                    .Set<Person>()
                    .Where(x => x.Cpf.Value == value && x.IsActive == true)
                    .FirstOrDefaultAsync();
        }

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public Task<Person> FindPersonByEmailAsync(string value)
        {
            return _context
                    .Set<Person>()
                    .Where(x => x.Email.Value == value && x.IsActive == true)
                    .FirstOrDefaultAsync();
        }

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        //   token:
        //     The token param.
        //
        public async Task<IDictionary<Guid, Person>> FindPersonsByIdAsync(IEnumerable<Guid> userIds, CancellationToken token)
        {
            return await _context
                    .Set<Person>()
                    .Where(x => userIds.Contains(x.Id))
                    .ToDictionaryAsync(a => a.Id);
        }
    }
}