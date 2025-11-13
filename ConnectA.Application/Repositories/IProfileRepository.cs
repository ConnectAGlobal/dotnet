using ConnectA.Domain.Entities;

namespace ConnectA.Application.Repositories;

public interface IProfileRepository
{
    Task<Profile> CreateProfileAsync(Profile profile);
}