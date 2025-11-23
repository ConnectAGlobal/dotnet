using ConnectA.Application.Repositories;

namespace ConnectA.Application.UseCases.Mentored;

public class DeleteFollowUseCase
{
    private readonly ILearningTrackUserRepository _repository;

    public DeleteFollowUseCase(ILearningTrackUserRepository repository) => _repository = repository;

    public Task Execute(Guid id)
        => _repository.DeleteAsync(id);
}
