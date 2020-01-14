using System;

namespace ChiquinhoTec.GerenciadorContratacao.Common
{
//
    // Summary:
    //     /// Classe responsável pelo BaseRepository. ///
    //
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;

        //
        // Summary:
        //     /// Médodo responsável por inicializar o repository. ///
        //
        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        //
        // Summary:
        //     /// Método responsável por criar um registro. ///
        //
        // Parameters:
        //   entity:
        //     The entity param.
        //
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        //
        // Summary:
        //     /// Método responsável por buscar todos os registros. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public Task<List<T>> FindAllAsync()
        {
            return _context.Set<T>().ToListAsync();
        }

        //
        // Summary:
        //     /// Método responsável por buscar todos os registros - paginados. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public Task<List<T>> FindAllAsync(int skip, int take)
        {
            return _context.Set<T>().Skip(skip).Take(take).ToListAsync();
        }

        //
        // Summary:
        //     /// Método responsável por buscar um registro pelo ID. ///
        //
        // Parameters:
        //   id:
        //     The id param.
        //
        public Task<T> FindAsync(Guid id)
        {
            return _context.FindAsync<T>(id);
        }

        //
        // Summary:
        //     /// Método responsável por remover um registro. ///
        //
        // Parameters:
        //   entity:
        //     The entity param.
        //
        public async Task RemoveAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        //
        // Summary:
        //     /// Método responsável por atualizar um registro. ///
        //
        // Parameters:
        //   entity:
        //     The entity param.
        //
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            
            await _context.SaveChangesAsync();
        }
    }
}