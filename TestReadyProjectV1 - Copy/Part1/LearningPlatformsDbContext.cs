// EF Core types: DbContext, DbContextOptions, DbSet.
using Microsoft.EntityFrameworkCore;

// Same namespace as my entity class file so Program.cs can reference both types together.
namespace TechForums;

// Database session for this app: connects EF Core to SQLite and exposes tables as DbSets.
public sealed class TechForumsDbContext : DbContext
{
    // Constructor receives options created in Program.cs (provider, connection string, etc.).
    public TechForumsDbContext(DbContextOptions<TechForumsDbContext> options) : base(options)
    {
        // No extra initialisation; base(options) wires up the context.
    }

    // DbSet for the mapped entity table; queried in LINQ as db.<this property name>.
    public DbSet<TechForum> TechForums { get; set; } = null!;
}
