using Catalog.Application;
using Catalog.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogContainer(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddSharedKernel(configuration, assembly);

        services.AddDbContext<CatalogDbContext>((sp, options) =>
        {
            options.UseNpgsql(configuration.GetConnectionString("catalogdb"));
            //options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });

        services.AddScoped<ICatalogUnitOfWork, CatalogUnitOfWork>();

        return services;
    }
}
