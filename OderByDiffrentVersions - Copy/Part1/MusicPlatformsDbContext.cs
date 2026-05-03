using Microsoft.EntityFrameworkCore;

namespace MusicPlatforms; // YOU choose; must match Part1.csproj and MusicPlatforms.cs

public sealed class MusicPlatformsDbContext : DbContext // YOU choose; must match Program.cs — example: new MusicPlatformsDbContext(options)
{
    public MusicPlatformsDbContext(DbContextOptions<MusicPlatformsDbContext> options) : base(options) { }

    // <> MusicPlatform: MUST be the same name as public class MusicPlatform in MusicPlatforms.cs (your one-row type). // MusicPlatforms (property): YOU choose, but it must match db.MusicPlatforms in Program.cs — often plural of the table/entity; it is NOT auto-read from the .db file. // From the database: only [Table]/[Column] on the entity map to SQL; namespace, context name, and this property name are C# choices.
    public DbSet<MusicPlatform> MusicPlatforms { get; set; } = null!;
}
