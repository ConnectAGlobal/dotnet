using ConnectA.Domain.Entities;

namespace ConnectA.Application.Services;

public static class UserToMLTextMapper
{
    public static string BuildSeniorText(User senior)
    {
        var tracks = string.Join(" ", senior.LearningTracksAsSenior.Select(t => t.Description));

        return $"{senior.Profile.Skills} {senior.Profile.Objectives} {tracks}";
    }

    public static string BuildJuniorText(User junior)
    {
        var tracks = string.Join(" ", junior.LearningTracksFolows.Select(t => t.LearningTrack.Description));

        return $"{junior.Profile.Skills} {junior.Profile.Objectives} {tracks}";
    }
}