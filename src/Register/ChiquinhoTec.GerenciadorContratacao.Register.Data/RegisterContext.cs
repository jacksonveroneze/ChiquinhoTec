using ChiquinhoTec.GerenciadorContratacao.Register.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Data
{
    public class RegisterContext : DbContext
    {
        public RegisterContext(DbContextOptions<RegisterContext> options) : base(options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(RegisterContext).Assembly);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies();
    }
}