using System;

namespace ChiquinhoTec.GerenciadorContratacao.Common
{
    //
    // Summary:
    //     /// Interface responsável pelo contrato. ///
    //
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        Task AddAsync(T entity);

        Task<T> FindAsync(Guid id);

        Task<List<T>> FindAllAsync();

        Task<List<T>> FindAllAsync(int skip, int take);

        Task RemoveAsync(T entity);

        Task UpdateAsync(T entity);
    }
}