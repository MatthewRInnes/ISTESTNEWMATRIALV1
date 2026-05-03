using Microsoft.EntityFrameworkCore;

namespace MusicPlatforms;

// EF Core context — same role as TechForumsDbContext in your TechForums Part 1 / Part 2 projects.
public sealed class MusicPlatformsDbContext : DbContext
{
    public MusicPlatformsDbContext(DbContextOptions<MusicPlatformsDbContext> options) : base(options)
    {
    }

    // Maps to table MusicPlatforms — query this set in Program.cs (Part 1) or Index.cshtml.cs (Part 2).
    public DbSet<MusicPlatform> MusicPlatforms { get; set; } = null!;
}
