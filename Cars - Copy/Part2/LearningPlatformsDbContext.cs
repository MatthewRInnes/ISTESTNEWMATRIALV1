using Microsoft.EntityFrameworkCore; // EF Core library that lets the web app query SQLite.

namespace Cars; // Same project namespace as `LearningSite.cs` (Car) and `Pages/Index.cshtml.cs`.

// FILE TYPE: DbContext for the web app.
// WHAT IT IS: `CarsDbContext` is the “database connection + query helper” class.
// WHAT IT IS NOT: it is NOT a table row; the entity class (`Car`) is the table row.
public sealed class CarsDbContext : DbContext
{
    // CONSTRUCTOR: dependency injection passes configuration in here.
    // Same DbContext type as Program.cs registers:
    // `builder.Services.AddDbContext<CarsDbContext>(...)`
    public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
    {
    }

    // DbSet = “table” as a C# collection.
    // Used like this in code:
    // - Index.cshtml.cs query starts: `_db.Cars`
    // - SQL table name is in the entity mapping: LearningSite.cs has `[Table("Cars")]`
    //   (same as `CREATE TABLE Cars` in Cars.sql)
    public DbSet<Car> Cars { get; set; } = null!;
}
