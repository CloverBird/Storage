using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Storage.Core.Services;
using Storage.DataBase.DbContexts;
using Storage.DataBase.Services;

namespace Storage.Database.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) {
        var connectionString = configuration.GetSection("Database:ConnectionString").Value;

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),   
                    options => {
                        options.MigrationsAssembly("Storage.DataBase");
                    })
        );

        services.TryAddScoped<IProductsBatchesService, ProductsBatchesService>();

        return services;
    }
}