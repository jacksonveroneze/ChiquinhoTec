using System;

namespace ChiquinhoTec.GerenciadorContratacao.Common
{
    //
    // Summary:
    //     /// Classe responsável pela BaseEntity. ///
    //
    public class BaseEntity : IBaseEntity
    {
        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; set; } = null;

        public DateTime? DeletedAt { get; set; } = null;

        public bool IsActive { get; set; } = true;

        //
        // Summary:
        //     /// Médodo responsável por inicializar a entidade. ///
        //
        protected BaseEntity() => CreatedAt = DateTime.Now;

        //
        // Summary:
        //     /// Médodo responsável por retornar 
        //     uma representação do objeto em string. ///
        //
        public override string ToString() => string.Empty;
    }
}