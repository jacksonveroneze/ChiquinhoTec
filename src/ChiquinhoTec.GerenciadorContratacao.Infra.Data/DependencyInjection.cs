using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("NorthwindDatabase")));

            services.AddScoped<ApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}