using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedNever();

            builder.Property(e => e.PostalCode)
                .HasColumnName("postal_code")
                .HasColumnType("varchar(9)")
                .IsRequired();

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.Property(e => e.City)
                .HasColumnName("city")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.District)
                .HasColumnName("district")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Street)
                .HasColumnName("street")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.StreetNumber)
                .HasColumnName("street_number")
                .HasColumnType("integer")
                .IsRequired();

            builder.Property(e => e.Complement)
                .HasColumnName("complement")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.PrimaryAddress)
                .HasColumnName("primary_address")
                .HasColumnType("boolean")
                .IsRequired();

            builder.HasOne(p => p.Person)
                .WithMany(b => b.Adresses)
                .HasForeignKey("person_id")
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_adress_person");

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