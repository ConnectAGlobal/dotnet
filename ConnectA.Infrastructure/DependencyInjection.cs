using ConnectA.Application.Configurations;
using ConnectA.Application.Repositories;
using ConnectA.Infrastructure.Persistence;
using ConnectA.Infrastructure.Repositories;
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
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<ILearningTrackRepository, LearningTrackRepository>();
        services.AddScoped<ITrackStageRepository, TrackStageRepository>();
        services.AddScoped<ILearningTrackUserRepository, LearningTrackUserRepository>();
        services.AddScoped<IMentorshipMatchRepository, MentorshipMatchRepository>();
        return services;
    }
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, Settings settings)
    {
        services.AddDbContext(settings.ConnectionStrings);
        services.AddRepositories();
        return services;
    }

}