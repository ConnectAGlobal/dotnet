using ConnectA.Domain.Entities;
using ConnectA.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ConnectA.Infrastructure.Persistence;

internal class OracleContext(DbContextOptions<OracleContext> options) : DbContext(options)
{
    
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<LearningTrack> LearningTracks { get; set; }
    public DbSet<LearningTrackUser> LearningTrackUsers { get; set; }
    public DbSet<MentorshipChallenge> MentorshipChallenges { get; set; }
    public DbSet<MentorshipEvaluation> MentorshipEvaluations { get; set; }
    public DbSet<MentorshipMatch> MentorshipMatches { get; set; }
    public DbSet<TrackStage> TrackStages { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new ProfileMapping());
        modelBuilder.ApplyConfiguration(new LearningTrackMapping());
        modelBuilder.ApplyConfiguration(new LearningTrackUserMapping());
        modelBuilder.ApplyConfiguration(new MentorshipChallengeMapping());
        modelBuilder.ApplyConfiguration(new MentorshipEvaluationMapping());
        modelBuilder.ApplyConfiguration(new MentorshipMatchMapping());
        modelBuilder.ApplyConfiguration(new TrackStageMapping());
    }
}