using Microsoft.EntityFrameworkCore;

namespace LearningPlatforms; // must match Part2.csproj RootNamespace and LearningSite.cs

public sealed class LearningPlatformsDbContext : DbContext // must match Program.cs AddDbContext<LearningPlatformsDbContext> — example: builder.Services.AddDbContext<LearningPlatformsDbContext>(…)
{
    public LearningPlatformsDbContext(DbContextOptions<LearningPlatformsDbContext> options) : base(options) // must match DI registration in Program.cs
    {
    }

    public DbSet<LearningSite> LearningSites { get; set; } = null!; // WHAT: LearningSite = one-row class (LearningSite.cs). LearningSites = DbSet for whole table. MUST MATCH: <LearningSite> ↔ public class LearningSite; LearningSites ↔ _db.LearningSites / Model.LearningSites. RENAME: change class + <> + List + file together. NOT: database filename.
}
