using LaNacion.Application.Interfaces;
using LaNacion.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LaNacion.Shared
{
    public static class ServiceExtensions
    {
        public static void AddInfraestructureShared(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }

    }
}
