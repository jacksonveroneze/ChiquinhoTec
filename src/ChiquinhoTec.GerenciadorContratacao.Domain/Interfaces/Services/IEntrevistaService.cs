using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    public class IEntrevistaService : IBaseService
    {
        Task<Entrevista> AddAsync(EntrevistaCommand command);

        Task RemoveAsync(Guid id);

        Task<Entrevista> UpdateAsync(EntrevistaCommand command, Guid id);
    }
}