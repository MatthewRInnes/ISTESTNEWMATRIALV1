// EF Core base types for DbContext and sets.
using Microsoft.EntityFrameworkCore;

// Keeps entity types and context in one namespace for Part 2.
namespace TechForums;

// EF Core database context registered in Program.cs for dependency injection into Razor Pages.
public sealed class TechForumsDbContext : DbContext
{
    // DI passes options (SQLite, connection string) from the service container.
    public TechForumsDbContext(DbContextOptions<TechForumsDbContext> options) : base(options)
    {
    }

    // DbSet for the mapped entity table; typical query: _db.<property>.OrderBy(...).ToListAsync() on pages.
    public DbSet<TechForum> TechForums { get; set; } = null!;
}
