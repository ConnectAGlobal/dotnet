using ConnectA.Application.Configurations;
using ConnectA.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectA.Infrastructure;

public static class DependencyInjection
{
    private static IServiceCollection AddDbContext(this IServiceCollection services, ConnectionSettings connectionSettings)
    {
        var connectionString = connectionSettings.OracleConnection;
        services.AddDbContext<OracleContext>(options =>
        {
            options.UseOracle(connectionString);
        });

        return services;
    }
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, Settings settings)
    {
        services.AddDbContext(settings.ConnectionStrings);
        return services;
    }

}