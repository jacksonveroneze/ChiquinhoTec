using ChiquinhoTec.GerenciadorContratacao.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Interfaces.Repositories;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Data.Repositories
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
        public AddressRepository(RegisterContext context) : base(context) { }

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
                        .Where(x => x.Person.Id == personId && x.IsActive)
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
        public Task<Address> FindCurrentPrimaryAddressByPersonId(Guid personId)
        {
            return _context
                        .Set<Address>()
                        .Where(x => x.Person.Id == personId && x.PrimaryAddress && x.IsActive)
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
        public bool HasAddressesByPersonId(Guid personId)
        {
            return _context
                        .Set<Address>()
                        .Any(x => x.Person.Id == personId && x.IsActive);
        }
    }
}