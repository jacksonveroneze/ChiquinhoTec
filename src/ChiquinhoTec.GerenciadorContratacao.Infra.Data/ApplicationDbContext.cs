using ChiquinhoTec.GerenciadorContratacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}