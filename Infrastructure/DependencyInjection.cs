using Domain;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("Database") ??
                                 throw new ArgumentNullException(nameof(configuration));
        services.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseNpgsql(dbConnectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}