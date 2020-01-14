using System;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Configurations
{
    public class EntrevistaConfiguration : IEntityTypeConfiguration<Entrevista>
    {
        public void Configure(EntityTypeBuilder<Entrevista> builder)
        {
            builder.ToTable("entrevista");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
        }
    }
}