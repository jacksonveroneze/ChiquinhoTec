using System;
using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Configurations
{
    public class InterviewConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.ToTable("interview");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(c => c.Date)
                .HasColumnName("date")
                .HasColumnType("date")
                .HasDefaultValueSql("null");

            builder.Property(c => c.Schedule)
                .HasColumnName("schedule")
                .HasColumnType("time")
                .HasDefaultValueSql("null");

            builder.Property(e => e.Squad)
                .HasColumnName("squad")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(p => p.Person)
                .WithMany(b => b.Interviews)
                .HasForeignKey("person_id")
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_Interview_person");

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime")
                .HasDefaultValueSql("null");

            builder.Property(c => c.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime")
                .HasDefaultValueSql("null");

            builder.Property(c => c.IsActive)
                .HasColumnName("is_active")
                .HasColumnType("boolean")
                .HasDefaultValueSql("true");

            builder.Property(c => c.Version)
                .HasColumnName("version")
                .HasColumnType("integer")
                .HasDefaultValueSql("1")
                .IsRequired();
        }
    }
}