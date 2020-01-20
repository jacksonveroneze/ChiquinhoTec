using ChiquinhoTec.GerenciadorContratacao.Common;
using System;

namespace ChiquinhoTec.GerenciadorContratacao.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the entity. ///
    //    
    public class EntityAudit : BaseEntity
    {
        public EntityAudit() { }

        public EntityAudit(string rev, Guid entityId, string name, string content) : base()
        {
            Rev = rev;
            EntityId = entityId;
            Name = name;
            Content = content;
        }

        public string Rev { get; private set; }

        public Guid EntityId { get; private set; }

        public string Name { get; private set; }

        public string Content { get; private set; }
    }
}