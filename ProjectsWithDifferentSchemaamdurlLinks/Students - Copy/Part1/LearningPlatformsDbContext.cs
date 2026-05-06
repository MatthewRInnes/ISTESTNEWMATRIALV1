using Microsoft.EntityFrameworkCore; // EF Core library that lets C# talk to SQLite.

namespace Students; // MUST match the namespace in `LearningSite.cs` (so Student + StudentsDbContext are in the same project namespace).

// `StudentsDbContext` = your “database connection + query helper” class.
// You do NOT guess data field names here; it just exposes the table(s) you can query.
public sealed class StudentsDbContext : DbContext
{
    // EF passes configuration in here (database provider + connection string).
    // MUST match the type used in Program.cs: `new DbContextOptionsBuilder<StudentsDbContext>()`.
    public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
    {
    }

    // `DbSet<Student>` means “the Students table as C# objects”.
    // MUST match these example lines elsewhere:
    // - Program.cs query starts: `db.Students`
    // - SQL table name lives in the entity: LearningSite.cs has `[Table("Students")]`
    public DbSet<Student> Students { get; set; } = null!;
}
