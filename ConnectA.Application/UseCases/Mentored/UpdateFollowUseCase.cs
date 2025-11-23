using ConnectA.Application.Repositories;
using ConnectA.Domain.Entities;
using ConnectA.Domain.Enums;
using System;

namespace ConnectA.Application.UseCases.Mentored;

public class UpdateFollowUseCase
{
    private readonly ILearningTrackUserRepository _repository;

    public UpdateFollowUseCase(ILearningTrackUserRepository repository) => _repository = repository;

    public async Task<LearningTrackUser> Execute(Guid id, Status? status, double? score, DateTime? completedAt)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            throw new ArgumentException("Follow not found.");

        if (status.HasValue)
            entity.Status = status.Value;

        if (score.HasValue)
            entity.Score = score.Value;

        if (completedAt.HasValue)
            entity.CompletedAt = completedAt;

        await _repository.UpdateAsync(entity);
        return entity;
    }
}
