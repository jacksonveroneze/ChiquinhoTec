using Microsoft.EntityFrameworkCore;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Data
{
    public class RegisterContextFactory : DesignTimeDbContextFactoryBase<RegisterContext>
    {
        protected override RegisterContext CreateNewInstance(DbContextOptions<RegisterContext> options)
            => new RegisterContext(options);
    }
}