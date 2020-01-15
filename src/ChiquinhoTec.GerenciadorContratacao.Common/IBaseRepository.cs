using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Common
{
    //
    // Summary:
    //     /// Interface responsible for contrat(IBaseRepository). ///
    //
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task AddAsync(T entity);

        ValueTask<T> FindAsync(Guid id);

        Task<List<T>> FindAllAsync();

        Task<List<T>> FindAllAsync(int skip, int take);

        Task RemoveAsync(T entity);

        Task UpdateAsync(T entity);
    }
}