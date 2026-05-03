using Microsoft.EntityFrameworkCore;

namespace Set09.Events.Part1;

// This is the “database helper” used to read the SQLite file.
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // Nothing else needed here.
    }

    // This name (`Items`) is what your code will query.
    public DbSet<Item> Items { get; set; } = null!;
}
