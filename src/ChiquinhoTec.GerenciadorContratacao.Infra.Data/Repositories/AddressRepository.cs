using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //
        // Summary:
        //     /// Method responsible for searching the data. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public Task<List<Address>> FindAddressesByPersonId(Guid personId)
        {
            return _context
                        .Set<Address>()
                        .Where(x => x.Person.Id == personId && x.IsActive == true)
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
        public bool HasAddressesByPersonId(Guid personId)
        {
            int total = _context
                            .Set<Address>()
                            .Where(x => x.Person.Id == personId && x.IsActive == true)
                            .Count();

            return total > 0;
        }
    }
}