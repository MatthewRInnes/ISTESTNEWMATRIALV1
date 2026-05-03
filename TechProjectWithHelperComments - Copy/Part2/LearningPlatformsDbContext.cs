using Microsoft.EntityFrameworkCore;

namespace TechForums; // must match Part2.csproj RootNamespace and LearningSite.cs

public sealed class TechForumsDbContext : DbContext // must match Program.cs AddDbContext<TechForumsDbContext> — example: builder.Services.AddDbContext<TechForumsDbContext>(…)
{
    public TechForumsDbContext(DbContextOptions<TechForumsDbContext> options) : base(options) // must match DI registration in Program.cs
    {
    }

    public DbSet<TechForum> TechForums { get; set; } = null!; // must match _db.LearningSites in Pages/Index.cshtml.cs — example: await _db.LearningSites.ToListAsync()
}
