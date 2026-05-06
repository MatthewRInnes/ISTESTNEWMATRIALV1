using Microsoft.EntityFrameworkCore; // EF Core base types (DbContext / DbSet).

namespace Students; // Groups your Student + StudentsDbContext types together.

// DbContext = “database session” object you query through.
public sealed class StudentsDbContext : DbContext
{
    // Constructor takes EF Core configuration (provider + connection string).
    public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
    {
    }

    // DbSet = a table you can query; each row becomes one Student object.
    public DbSet<Student> Students { get; set; } = null!;
}
