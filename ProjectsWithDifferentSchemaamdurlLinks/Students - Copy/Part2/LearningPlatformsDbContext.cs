using Microsoft.EntityFrameworkCore; // EF Core library that lets the web app query SQLite.

namespace Students; // MUST match the namespace in `LearningSite.cs` (Student) and `Pages/Index.cshtml.cs`.

// `StudentsDbContext` = the web app’s “database connection + query helper” class.
// It is registered in Program.cs so Razor Pages can use it.
public sealed class StudentsDbContext : DbContext
{
    // ASP.NET Core dependency injection passes configuration in here.
    // MUST match this Program.cs line: `builder.Services.AddDbContext<StudentsDbContext>(...)`
    public StudentsDbContext(DbContextOptions<StudentsDbContext> options) : base(options)
    {
    }

    // `DbSet<Student>` means “the Students table as C# objects”.
    // MUST match these example lines elsewhere:
    // - Index.cshtml.cs query starts: `_db.Students`
    // - SQL table name lives in the entity: LearningSite.cs has `[Table("Students")]`
    public DbSet<Student> Students { get; set; } = null!;
}
