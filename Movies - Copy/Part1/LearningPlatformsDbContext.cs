using Microsoft.EntityFrameworkCore; // EF Core library that lets C# talk to SQLite.

namespace Movies; // MUST match the namespace in `LearningSite.cs` (so Student + MoviesDbContext are in the same project namespace).

// `MoviesDbContext` = your “database connection + query helper” class.
// You do NOT guess data field names here; it just exposes the table(s) you can query.
public sealed class MoviesDbContext : DbContext
{
    // EF passes configuration in here (database provider + connection string).
    // MUST match the type used in Program.cs: `new DbContextOptionsBuilder<MoviesDbContext>()`.
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
    {
    }

    // `DbSet<Student>` means “the Movies table as C# objects”.
    // MUST match these example lines elsewhere:
    // - Program.cs query starts: `db.Movies`
    // - SQL table name lives in the entity: LearningSite.cs has `[Table("Movies")]`
    public DbSet<Movie> Movies { get; set; } = null!;
}
