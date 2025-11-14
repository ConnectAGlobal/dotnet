using System.Net;
using System.Net.Http.Json;
using ConnectA.API.Controllers;
using ConnectA.API.DTOs.Request;
using ConnectA.API.DTOs.Response;
using JetBrains.Annotations;

namespace ConnectA.Tests.Controllers;

[TestSubject(typeof(ProfileController))]
public class ProfileControllerTest(ApiFactory factory) : IClassFixture<ApiFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task CreateProfile_WhenValidData_ShouldReturnCreated()
    {
        var userId = await CreateUserAsync();
        
        var dto = new ProfileRequestDTO(userId, "Existing Bio", "Existing Skills", "Existing Work Experience",
            "Existing Goals", "SP", "en, pt");
        
        var response = await _client.PostAsJsonAsync("/api/v1/profiles", dto);
        
        if (!response.IsSuccessStatusCode)
        {
            var errorBody = await response.Content.ReadAsStringAsync();
            throw new Exception($"Status: {response.StatusCode}. Body: {errorBody}");
        }
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        
        var created = await response.Content.ReadFromJsonAsync<ProfileResponseDTO>();
        Assert.NotNull(created);
        Assert.Equal(dto.UserId, created.UserId);
    }
    
    private async Task<Guid> CreateUserAsync()
    {
        var userDto = new UserRequestDTO("Test User", $"test{Guid.NewGuid()}@test.com", "123456@aS", "Senior");

        var response = await _client.PostAsJsonAsync("/api/v1/users", userDto);
        if (!response.IsSuccessStatusCode)
        {
            var errorBody = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro ao criar usuário. Status: {response.StatusCode}. Body: {errorBody}");
        }
        
        var createdUser = await response.Content.ReadFromJsonAsync<UserResponseDTO>();
        return createdUser.Id;
    }
}