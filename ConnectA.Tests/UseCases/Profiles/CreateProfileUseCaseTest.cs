using ConnectA.Application.Repositories;
using ConnectA.Application.UseCases.Profiles;
using ConnectA.Domain.Entities;
using ConnectA.Domain.Exceptions;
using JetBrains.Annotations;
using Moq;

namespace ConnectA.Tests.UseCases.Profiles;

[TestSubject(typeof(CreateProfileUseCase))]
public class CreateProfileUseCaseTest
{
    
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IProfileRepository> _profileRepositoryMock;
    private readonly CreateProfileUseCase _createProfileUseCase;
    
    public CreateProfileUseCaseTest()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _profileRepositoryMock = new Mock<IProfileRepository>();

        _createProfileUseCase = new CreateProfileUseCase(
            _profileRepositoryMock.Object,
            _userRepositoryMock.Object
        );
    }

    [Fact]
    public void CreateProfile_WhenUserDoesNotExist_ShouldThrowUserNotFoundException()
    {
        _userRepositoryMock.Setup(repo => repo.GetUserByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((User?) null);
        var profile = new Profile(Guid.Empty, "Test Bio", "Programação, Engenheiro de Software, Git, ", "Trabalho .....", "Conseguir vaga .....", "SP", "en, pt");
        Assert.ThrowsAsync<UserNotFoundException>(async () =>
        {
            await _createProfileUseCase.CreateProfile(profile);
        });
    }

    [Fact]
    public void CreateProfile_WhenProfileAlreadyExists_ShouldThrowProfileAlreadyExistsException()
    {
        var user = new User("Tester", "Tester@gmail.com", "123456789", "Senior");
        _userRepositoryMock.Setup(repo => repo.GetUserByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((User?) user);
        
        user.Profile = new Profile(user.Id, "Existing Bio", "Existing Skills", "Existing Work Experience", "Existing Goals", "SP", "en, pt");
        var profile = new Profile(user.Id, "Test Bio", "Programação, Engenheiro de Software, Git, ", "Trabalho .....", "Conseguir vaga .....", "SP", "en, pt");
        Assert.ThrowsAsync<ProfileAlreadyExistsException>(async () =>
        {
            await _createProfileUseCase.CreateProfile(profile);
        });
    }

    [Fact]
    public async void CreateProfile_WhenValidProfile_ShouldCreateProfileSuccessfully()
    {
        var user = new User("Tester", "Tester@gmail.com", "123456789", "Senior");
        _userRepositoryMock.Setup(repo => repo.GetUserByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((User?) user);
        var profile = new Profile(user.Id, "Test Bio", "Programação, Engenheiro de Software, Git, ", "Trabalho .....", "Conseguir vaga .....", "SP", "en, pt");
        _profileRepositoryMock.Setup(repo => repo.CreateProfileAsync(It.IsAny<Profile>()))
            .ReturnsAsync((Profile p) => p);
        var createdProfile = await _createProfileUseCase.CreateProfile(profile);
        Assert.NotNull(createdProfile);
        _profileRepositoryMock.Verify(r => r.CreateProfileAsync(profile), Times.Once);
    }
}