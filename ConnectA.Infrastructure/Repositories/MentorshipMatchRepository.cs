using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Persistence;

namespace ConnectA.Infrastructure.Repositories;

internal class MentorshipMatchRepository(OracleContext context) : IMentorshipMatchRepository
{
    public async Task SaveAsync(MentorshipMatch mentorshipMatch)
    {
        await context.MentorshipMatches.AddAsync(mentorshipMatch);
        await context.SaveChangesAsync();
    }
}