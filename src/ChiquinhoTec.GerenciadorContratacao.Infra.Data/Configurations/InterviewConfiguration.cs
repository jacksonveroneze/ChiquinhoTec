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

            builder.Property(c => c.SchedulingDate)
                .HasColumnName("scheduling_date")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(e => e.Squad)
                .HasColumnName("squad")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(p => p.Person)
                .WithMany(b => b.Interviews)
                .HasForeignKey("person_id")
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_interview_person");

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