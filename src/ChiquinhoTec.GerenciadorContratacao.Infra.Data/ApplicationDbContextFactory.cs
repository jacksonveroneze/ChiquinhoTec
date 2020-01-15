using System;
using Microsoft.EntityFrameworkCore;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Configurations
{
    public class ApplicationDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext>
    {
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }
    }
}