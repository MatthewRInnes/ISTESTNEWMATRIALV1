using Microsoft.EntityFrameworkCore;

namespace TechForums; // must match Part1.csproj RootNamespace and LearningSite.cs — example: namespace TechForums;

public sealed class TechForumsDbContext : DbContext // must match Program.cs DbContextOptionsBuilder<TechForumsDbContext> — example: new DbContextOptionsBuilder<TechForumsDbContext>()
{
    public TechForumsDbContext(DbContextOptions<TechForumsDbContext> options) : base(options) // must match constructor call new TechForumsDbContext(options) in Program.cs
    {
    }

    public DbSet<TechForum> TechForums { get; set; } = null!; // must match Program.cs db.TechForums — example: await db.TechForums.Where(...)
}
