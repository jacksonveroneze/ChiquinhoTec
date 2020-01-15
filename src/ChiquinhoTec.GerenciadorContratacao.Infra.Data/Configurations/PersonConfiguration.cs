using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using ChiquinhoTec.GerenciadorContratacao.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.BirthDate)
                .HasColumnName("birthDate")
                .HasColumnType("date")
                .IsRequired();

            builder.OwnsOne<Cpf>(e => e.Cpf, v =>
            {
                v.Property(c => c.Value)
                .HasColumnName("cpf")
                .HasColumnType("varchar(11)")
                .IsRequired();

                v.HasIndex(b => b.Value).IsUnique();
            });

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.OwnsOne<Email>(e => e.Email, v =>
            {
                v.Property(c => c.Value)
                .HasColumnName("email")
                .HasColumnType("varchar(100)")
                .IsRequired();

                v.HasIndex(b => b.Value).IsUnique();
            });

            builder.Property(e => e.Profile)
                .HasColumnName("profile")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.ProfessionalDescription)
                .HasColumnName("professional_description")
                .HasColumnType("varchar(100)")
                .IsRequired();

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