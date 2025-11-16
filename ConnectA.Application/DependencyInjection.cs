using ConnectA.Application.UseCases.Mentor;
using ConnectA.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectA.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<CreateUserUseCase>();
        services.AddScoped<CreateLearningTrackUseCase>();
        return services;
    }
}