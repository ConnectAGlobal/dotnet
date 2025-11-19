using ConnectA.Application.Services;
using ConnectA.Application.UseCases.Matching;
using ConnectA.Application.UseCases.Mentor;
using ConnectA.Application.UseCases.Mentored;
using ConnectA.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace ConnectA.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<CreateUserUseCase>();
        services.AddScoped<GetAllUsersUseCase>();
        services.AddScoped<DeleteUserUseCase>();
        services.AddScoped<CreateLearningTrackUseCase>();
        services.AddScoped<UpdateFollowUseCase>();
        services.AddScoped<DeleteFollowUseCase>();
        services.AddScoped<GenerateMatchUseCase>();
        services.AddScoped<AddTrackStageUseCase>();
        services.AddScoped<FollowLearningTrackListUseCase>();
        services.AddScoped<FollowLearningTrackUseCase>();
        services.AddScoped<EditProfileUseCase>();
        services.AddScoped<MatchingMLService>();
        return services;
    }
}