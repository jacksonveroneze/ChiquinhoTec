using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    public class IPessoaService : IBaseService
    {
        Task<Pessoa> AddAsync(PessoaCommand command);

        Task RemoveAsync(Guid id);

        Task<Pessoa> UpdateAsync(PessoaCommand command, Guid id);
    }
}