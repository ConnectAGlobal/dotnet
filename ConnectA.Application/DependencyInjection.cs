using ConnectA.Application.UseCases.Profiles;
using ConnectA.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectA.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<CreateUserUseCase>();
        services.AddScoped<CreateProfileUseCase>();
        return services;
    }
}