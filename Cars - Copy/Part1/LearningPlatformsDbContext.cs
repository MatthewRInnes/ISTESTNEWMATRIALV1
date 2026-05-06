using Microsoft.EntityFrameworkCore; // EF Core library that lets C# talk to SQLite.

namespace Cars; // MUST match the namespace in `LearningSite.cs` (so Student + CarsDbContext are in the same project namespace).

// `CarsDbContext` = your “database connection + query helper” class.
// You do NOT guess data field names here; it just exposes the table(s) you can query.
public sealed class CarsDbContext : DbContext
{
    // EF passes configuration in here (database provider + connection string).
    // MUST match the type used in Program.cs: `new DbContextOptionsBuilder<CarsDbContext>()`.
    public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
    {
    }

    // `DbSet<Student>` means “the Cars table as C# objects”.
    // MUST match these example lines elsewhere:
    // - Program.cs query starts: `db.Cars`
    // - SQL table name lives in the entity: LearningSite.cs has `[Table("Cars")]`
    public DbSet<Car> Cars { get; set; } = null!;
}
