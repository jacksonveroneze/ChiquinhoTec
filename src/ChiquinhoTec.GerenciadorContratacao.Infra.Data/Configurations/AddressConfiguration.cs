using System;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.PostalCode)
                .HasColumnName("postal_code")
                .HasColumnType("varchar(9)")
                .IsRequired();

            builder.Property(e => e.State)
                .HasColumnName("state")
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.Property(e => e.District)
                .HasColumnName("district")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.AddressNumber)
                .HasColumnName("address_number")
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
                .OnDelete(DeleteBehavior.Restrict);

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