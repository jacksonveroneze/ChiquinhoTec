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
                .HasColumnType("uuid")
                .ValueGeneratedNever();

            builder.Property(c => c.SchedulingDate)
                .HasColumnName("scheduling_date")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(e => e.Squad)
                .HasColumnName("squad")
                .HasColumnType("integer")
                .IsRequired();

            builder.HasOne(p => p.Person)
                .WithMany(b => b.Interviews)
                .IsRequired()
                .HasForeignKey("person_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp")
                .HasDefaultValueSql("null");

            builder.Property(c => c.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("timestamp")
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