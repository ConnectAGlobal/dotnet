using ConnectA.Application.Repositories;
using ConnectA.Application.UseCases.Mentored;
using ConnectA.Domain.Entities;
using ConnectA.Domain.Exceptions;
using ConnectA.Tests.Builders;
using JetBrains.Annotations;
using Moq;

namespace ConnectA.Tests.UseCases.Mentored;

[TestSubject(typeof(CreateLearningTrackUseCase))]
public class CreateLearningTrackUseCaseTest
{
    
    private readonly Mock<ILearningTrackRepository> _learningTrackRepository;
    private readonly Mock<ITrackStageRepository> _trackStageRepository;
    private readonly Mock<IUserRepository> _userRepository;
    private readonly CreateLearningTrackUseCase _createLearningTrackUseCase;
    
    public CreateLearningTrackUseCaseTest()
    {
        _learningTrackRepository = new Mock<ILearningTrackRepository>();
        _trackStageRepository = new Mock<ITrackStageRepository>();
        _userRepository = new Mock<IUserRepository>();

        _createLearningTrackUseCase = new CreateLearningTrackUseCase(
            _learningTrackRepository.Object,
            _trackStageRepository.Object,
            _userRepository.Object
        );
    }
    
    [Fact]
    public void CreateProfile_WhenUserDoesNotExist_ShouldThrowUserNotFoundException()
    {
        _userRepository.Setup(repo => repo.GetUserByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((User?) null);

        var learningTrack = LearningTrackBuilder.CreateValidTrack(Guid.Empty);
        
        Assert.ThrowsAsync<UserNotFoundException>(async () =>
        {
            await _createLearningTrackUseCase.CreateLearningTrack(learningTrack);
        });
    }
    
    [Fact]
    public async Task CreateLearningTrack_WhenUserIsNotSenior_ShouldThrowInvalidSeniorRoleException()
    {
        var profile = ProfileBuilder.CreateValidProfile();
        var user = UserBuilder.CreateValidJovem(profile);
        
        _userRepository.Setup(r => r.GetUserByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(user);

        var learningTrack = LearningTrackBuilder.CreateValidTrack(user.Id);

        await Assert.ThrowsAsync<InvalidSeniorRoleException>(async () =>
        {
            await _createLearningTrackUseCase.CreateLearningTrack(learningTrack);
        });
    }

    [Fact]
    public async Task CreateLearningTrack_WhenValidLearningTrack_ShouldCreateLearningTrackSuccessfully()
    {
        var profile = ProfileBuilder.CreateValidProfile();
        var user = UserBuilder.CreateValidSenior(profile);
        
        _userRepository.Setup(userRepo => userRepo.GetUserByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(user);
        
        var learningTrack = LearningTrackBuilder.CreateValidTrack(user.Id);
        
        _learningTrackRepository
            .Setup(r => r.CreateLearningTrack(It.IsAny<LearningTrack>()))
            .ReturnsAsync((LearningTrack lt) => lt);
        
        var createdLearningTrack =  await _createLearningTrackUseCase.CreateLearningTrack(learningTrack);
        Assert.NotNull(createdLearningTrack);
        _learningTrackRepository.Verify(r => r.CreateLearningTrack(learningTrack), Times.Once);
        _trackStageRepository.Verify(r => r.CreateTrackStages(learningTrack.Stages), Times.Once);
        Assert.NotNull(createdLearningTrack.Stages);
        Assert.Equal(createdLearningTrack.Id, createdLearningTrack.Stages.First().LearningTrackId);

    }
    
    
}