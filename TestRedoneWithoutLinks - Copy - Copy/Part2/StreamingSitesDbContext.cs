// DbContext, DbSet, and query extension types.
using Microsoft.EntityFrameworkCore;

// Shared namespace for my entity and this context class.
namespace StreamingSites;

// EF Core session: connects to the SQLite file and exposes tables as DbSet properties.
public class StreamingSitesDbContext : DbContext
{
    // DI supplies options (provider, connection string) chosen in Program.cs.
    public StreamingSitesDbContext(DbContextOptions<StreamingSitesDbContext> options) : base(options)
    {
        // base(options) attaches the configuration; no extra work required here.
    }

    // DbSet for the mapped table; I query it as _db.Channels in page models and program startup.
    public DbSet<Channel> Channels { get; set; } = null!;
}
