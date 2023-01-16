using LaNacion.Persistence.Contexts;
using LaNacion.Persistence.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace LaNacion.Contacts.API.IntegrationTests.Helpers
{
    public class ContactsApi<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(async services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ApplicationDbContext>));

                services.Remove(dbContextDescriptor);

                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbConnection));

                services.Remove(dbConnectionDescriptor);


                services.AddDbContext<ApplicationDbContext>((container, options) =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var applicationDbContext = scopedServices.GetRequiredService<ApplicationDbContext>();

                await ApplicationDbContextSeed.SeedSampleDataAsync(applicationDbContext);

                services.AddScoped<ApplicationDbContext>();

            });

            builder.UseEnvironment("Development");
        }
    }
}
