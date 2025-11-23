using ConnectA.Application.Repositories;
using ConnectA.Application.Services;
using ConnectA.Application.UseCases.Matching;
using ConnectA.Domain.Entities;
using ConnectA.Tests.Builders;
using JetBrains.Annotations;
using Microsoft.ML;
using Moq;


namespace ConnectA.Tests.UseCases.Matching;

[TestSubject(typeof(GenerateMatchUseCase))]
public class GenerateMatchUseCaseTests
{
    private readonly Mock<IUserRepository> _userRepoMock = new();
    private readonly Mock<IMentorshipMatchRepository> _matchRepoMock = new();
    

    private GenerateMatchUseCase CreateUseCase()
    {
        var ml = new MatchingMLService();
        return new GenerateMatchUseCase(
            _userRepoMock.Object,
            _matchRepoMock.Object,
            ml
        );
    }
    
    [Fact]
    public async Task Should_DoNothing_When_NoJuniors()
    {
        _userRepoMock.Setup(r => r.GetAvailableJuniorsAsync())
            .ReturnsAsync(new List<User>());

        _userRepoMock.Setup(r => r.GetAvailableSeniorsAsync())
            .ReturnsAsync(new List<User> { UserBuilder.CreateValidSenior(ProfileBuilder.CreateValidProfile()) });

        var usecase = CreateUseCase();
        
        await usecase.GenerateMatch();
        
        _matchRepoMock.Verify(r => r.SaveAsync(It.IsAny<MentorshipMatch>()), Times.Never);
    }
    
    [Fact]
    public async Task Should_DoNothing_When_NoSeniors()
    {
        
        _userRepoMock.Setup(r => r.GetAvailableJuniorsAsync())
            .ReturnsAsync(new List<User> { UserBuilder.CreateValidJovem(ProfileBuilder.CreateValidProfile()) });

        _userRepoMock.Setup(r => r.GetAvailableSeniorsAsync())
            .ReturnsAsync(new List<User>());

        var usecase = CreateUseCase();

        await usecase.GenerateMatch();

        _matchRepoMock.Verify(r => r.SaveAsync(It.IsAny<MentorshipMatch>()), Times.Never);
    }

    [Fact]
    public async Task Should_CreateMatch_WithBestSenior()
    {
        var junior = UserBuilder.CreateValidJovem(ProfileBuilder.CreateValidProfile());
        junior.Profile.Objectives = "backend api";
        junior.Profile.Skills = "C#, SQL";

        var senior1 = UserBuilder.CreateValidSenior(ProfileBuilder.CreateValidProfile());
        
        senior1.Profile.Objectives = "backend cloud";
        senior1.Profile.Skills = "C#, Docker";
        
        
        var senior3 = UserBuilder.CreateValidSenior(ProfileBuilder.CreateValidProfile());
        
        senior3.Profile.Objectives = "backend api";
        senior3.Profile.Skills = "C#, SQL";

        var senior2 = UserBuilder.CreateValidSenior(ProfileBuilder.CreateValidProfile());
        
        senior2.Profile.Objectives = "frontend design";
        senior2.Profile.Skills = "React, UI/UX";

        _userRepoMock.Setup(r => r.GetAvailableJuniorsAsync())
            .ReturnsAsync(new List<User> { junior });

        _userRepoMock.Setup(r => r.GetAvailableSeniorsAsync())
            .ReturnsAsync(new List<User> { senior1, senior2, senior3 });

        var ml = new MatchingMLService();

        var usecase = new GenerateMatchUseCase(
            _userRepoMock.Object,
            _matchRepoMock.Object,
            ml
        );

        await usecase.GenerateMatch();

        _matchRepoMock.Verify(r => r.SaveAsync(It.Is<MentorshipMatch>(m =>
                m.JuniorId == junior.Id &&
                m.SeniorId == senior3.Id
        )), Times.Once);
    }
    
    [Fact]
    public async Task Should_Generate_Match_For_Junior_And_Senior()
    {
        var junior = UserBuilder.CreateValidJovem(ProfileBuilder.CreateValidProfile());
        var senior = UserBuilder.CreateValidSenior(ProfileBuilder.CreateValidProfile());
        
        junior.Profile.Objectives = "apis";
        junior.Profile.Skills = "C# dev";
        
        senior.Profile.Objectives = "cloud";
        senior.Profile.Skills = "C#, backend";

        _userRepoMock.Setup(r => r.GetAvailableJuniorsAsync())
            .ReturnsAsync(new List<User> { junior });

        _userRepoMock.Setup(r => r.GetAvailableSeniorsAsync())
            .ReturnsAsync(new List<User> { senior });

        var ml = new MatchingMLService();
    
        var usecase = new GenerateMatchUseCase(
            _userRepoMock.Object,
            _matchRepoMock.Object,
            ml
        );

        await usecase.GenerateMatch();

        _matchRepoMock.Verify(r => r.SaveAsync(It.IsAny<MentorshipMatch>()), Times.Once);
    }
}
