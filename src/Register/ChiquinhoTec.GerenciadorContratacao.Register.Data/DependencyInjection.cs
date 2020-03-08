using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RegisterContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ApplicationDatabase"))).AddLogging();

            return services;
        }
    }
}