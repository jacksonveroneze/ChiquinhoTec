using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    public class IEnderecoService : IBaseService
    {
        Task<Endereco> AddAsync(EnderecoCommand command);

        Task RemoveAsync(Guid id);

        Task<Endereco> UpdateAsync(EnderecoCommand command, Guid id);
    }
}