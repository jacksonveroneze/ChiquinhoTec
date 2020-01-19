using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Configurations
{
    public class EntityAuditConfiguration : IEntityTypeConfiguration<EntityAudit>
    {
        public void Configure(EntityTypeBuilder<EntityAudit> builder)
        {
            builder.ToTable("entity_audit");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedNever();

            builder.Property(c => c.Rev)
                .HasColumnName("rev")
                .HasColumnType("varchar(3)")
                .IsRequired();

            builder.Property(e => e.EntityId)
                .HasColumnName("entity_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.Content)
                .HasColumnName("content")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("null");

            builder.Property(c => c.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("null");

            builder.Property(c => c.IsActive)
                .HasColumnName("is_active")
                .HasColumnType("boolean");

            builder.Property(c => c.Version)
                .HasColumnName("version")
                .HasColumnType("integer")
                .IsRequired();
        }
    }
}