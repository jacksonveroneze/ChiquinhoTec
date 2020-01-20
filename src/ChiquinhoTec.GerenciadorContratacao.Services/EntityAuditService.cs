using ChiquinhoTec.GerenciadorContratacao.Common;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Repositories;
using ChiquinhoTec.GerenciadorContratacao.Domain.Interfaces.Services;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ChiquinhoTec.GerenciadorContratacao.Services
{
    //
    // Summary:
    //     /// Class responsible for the service. ///
    //
    public class EntityAuditService : BaseService, IEntityAuditService
    {
        private readonly IEntityAuditRepository _entityAuditRepository;

        //
        // Summary:
        //     /// Method responsible for initializing the service. ///
        //
        // Parameters:
        //   entityAuditRepository:
        //     The entityAuditRepository param.
        //
        public EntityAuditService(IEntityAuditRepository entityAuditRepository)
            => _entityAuditRepository = entityAuditRepository;

        //
        // Summary:
        //     /// Method responsible for create registry. ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        public async Task<EntityAudit> AddAsync(string rev, string name, BaseEntity entity)
        {
            string json = JsonConvert.SerializeObject(entity, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            EntityAudit entityAudit = new EntityAudit(rev, entity.Id, name, json);

            await _entityAuditRepository.AddAsync(entityAudit);

            return entityAudit;
        }
    }
}