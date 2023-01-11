using LaNacion.Application.Interfaces;
using LaNacion.Persistence.Contexts;
using LaNacion.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaNacion.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddInfraestructurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(ApplicationRepositoryAsync<>));

        }
    }
}
