using ConnectA.Domain.Entities;

namespace ConnectA.Application.Repositories;

public interface IProfileRepository
{
    Task CreateProfileAsync(Profile profile);
    
    Task UpdateProfileAsync(Profile profile);
}