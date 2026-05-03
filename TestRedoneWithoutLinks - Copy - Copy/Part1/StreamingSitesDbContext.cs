// DbContext, DbSet, and query extension types.
using Microsoft.EntityFrameworkCore;

// Shared namespace for my entity and this context class (same as Part 2).
namespace StreamingSites;

// EF Core session: connects to the SQLite file and exposes the Channels table.
public class StreamingSitesDbContext : DbContext
{
    // Options built in Program.cs (SQLite provider and connection string path).
    public StreamingSitesDbContext(DbContextOptions<StreamingSitesDbContext> options) : base(options)
    {
        // base(options) attaches the configuration; no extra work required here.
    }

    // DbSet for the mapped table; queried in Program.cs as db.Channels.
    public DbSet<Channel> Channels { get; set; } = null!;
}
