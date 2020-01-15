using System;

namespace ChiquinhoTec.GerenciadorContratacao.Common
{
    //
    // Summary:
    //     /// Class responsible for BaseEntity. ///
    //
    public abstract class BaseEntity : IBaseEntity
    {
        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; set; } = null;

        public DateTime? DeletedAt { get; set; } = null;

        public bool IsActive { get; set; } = true;

        public int Version { get; private set; } = 1;

        //
        // Summary:
        //     /// Method responsible for initializing the entity. ///
        //
        public BaseEntity() => CreatedAt = DateTime.Now;

        //
        // Summary:
        //     /// Method responsible for updating the entity. ///
        //
        public void IncrementVersion() => Version++;

        //
        // Summary:
        //     /// Method responsible for returning a string 
        //     representation of the object. ///
        //
        public override string ToString()
            => $"CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}, DeletedAt: {DeletedAt}, IsActive: {IsActive}, Version: {Version}";
    }
}