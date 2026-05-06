// EF Core types: DbContext, DbContextOptions, DbSet.
using Microsoft.EntityFrameworkCore;

// Same namespace as my entity class file so Program.cs can reference both types together.
namespace NewsSites;

// Database session for this app: connects EF Core to SQLite and exposes tables as DbSets.
public sealed class NewsSitesDbContext : DbContext
{
    // Constructor receives options created in Program.cs (provider, connection string, etc.).
    public NewsSitesDbContext(DbContextOptions<NewsSitesDbContext> options) : base(options)
    {
        // No extra initialisation; base(options) wires up the context.
    }

    // DbSet for the mapped entity table; queried in LINQ as db.<this property name>.
    public DbSet<NewsSite> NewsSites { get; set; } = null!;
}
