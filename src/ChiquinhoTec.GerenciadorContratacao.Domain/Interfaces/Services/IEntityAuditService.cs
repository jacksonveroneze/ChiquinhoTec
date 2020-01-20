using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services
{
    //
    // Summary:
    //     /// Interface responsible for contrat. ///
    //
    public interface IEntityAuditService : IBaseService
    {
        Task<EntityAudit> AddAsync(string rev, string name, BaseEntity entity);
    }
}