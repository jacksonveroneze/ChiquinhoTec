using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChiquinhoTec.GerenciadorContratacao.Common
{
    //
    // Summary:
    //     /// Class responsible for BaseRepository. ///
    //
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected readonly DbContext _context;

        //
        // Summary:
        //     /// Médodo responsável por inicializar o repository. ///
        //
        protected BaseRepository(DbContext context)
            => _context = context;

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public Task<T> FindAsync(Guid id)
            => _context
                .Set<T>()
                .Where(x => x.Id == id && x.IsActive == true)
                .FirstOrDefaultAsync();

        public Task<List<T>> FindAllAsync()
        {
            return _context.Set<T>().Where(x => x.IsActive == true).ToListAsync();
        }

        public Task<List<T>> FindAllAsync(int skip, int take)
            => _context.Set<T>().Skip(skip).Take(take).Where(x => x.IsActive == true).ToListAsync();


        public async Task RemoveAsync(T entity)
        {
            entity.IsActive = false;

            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.IncrementVersion();

            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}