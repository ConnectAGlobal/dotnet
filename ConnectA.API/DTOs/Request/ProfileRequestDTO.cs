using System.Text.Json.Serialization;

namespace ConnectA.API.DTOs.Request;

public class ProfileRequestDTO(
    Guid userId,
    string biography,
    string skills,
    string experience,
    string objectives,
    string location,
    string lenguages)
{
    [JsonPropertyName("userId")]
    public Guid UserId { get; init; } = userId;
    [JsonPropertyName("biography")]
    public string Biography { get; init; } = biography;
    [JsonPropertyName("skills")]
    public string Skills { get; init; } = skills;
    [JsonPropertyName("experience")]
    public string Experience { get; init; } = experience;
    [JsonPropertyName("objectives")]
    public string Objectives { get; init; } = objectives;
    [JsonPropertyName("location")]
    public string Location { get; init; } = location;
    [JsonPropertyName("lenguages")]
    public string Lenguages { get; init; } = lenguages;
}