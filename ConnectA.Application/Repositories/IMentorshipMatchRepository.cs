using ConnectA.Domain.Entities;

namespace ConnectA.Application.Repositories;

public interface IMentorshipMatchRepository
{
    Task SaveAsync(MentorshipMatch mentorshipMatch);
}