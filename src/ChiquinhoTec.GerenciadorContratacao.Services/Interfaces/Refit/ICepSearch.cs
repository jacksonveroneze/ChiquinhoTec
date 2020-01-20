using ChiquinhoTec.GerenciadorContratacao.Domain.Results;
using Refit;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Services.Interfaces.Refit
{
    public interface ICepSearch
    {
        [Get("/ws/{cep}/json/")]
        Task<CepResult> Find(string cep);
    }
}
