using ConnectA.Application.Pagination;
using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;

namespace ConnectA.Application.UseCases.Mentored;

public class FollowLearningTrackListUseCase(ILearningTrackUserRepository repository)
{
    public async Task<PagedResultDTO<LearningTrackUser>> GetFollowedLearningTracksAsync(Guid userId, int page, int pageSize)
    {
        var (items, totalCount) = await repository.GetFollowedLearningTracksPagedAsync(userId, page, pageSize);

        return new PagedResultDTO<LearningTrackUser>
        {
            Items = items,
            Page = page,
            PageSize = pageSize,
            TotalItems = totalCount,
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
        };
    }
}