using Microsoft.EntityFrameworkCore; // EF Core library that lets the web app query SQLite.

namespace Movies; // Same project namespace as `LearningSite.cs` (Movie) and `Pages/Index.cshtml.cs`.

// FILE TYPE: DbContext for the web app.
// WHAT IT IS: `MoviesDbContext` is the “database connection + query helper” class.
// WHAT IT IS NOT: it is NOT a table row; the entity class (`Movie`) is the table row.
public sealed class MoviesDbContext : DbContext
{
    // CONSTRUCTOR: dependency injection passes configuration in here.
    // Same DbContext type as Program.cs registers:
    // `builder.Services.AddDbContext<MoviesDbContext>(...)`
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
    {
    }

    // DbSet = “table” as a C# collection.
    // Used like this in code:
    // - Index.cshtml.cs query starts: `_db.Movies`
    // - SQL table name is in the entity mapping: LearningSite.cs has `[Table("Movies")]`
    //   (same as `CREATE TABLE Movies` in Movies.sql)
    public DbSet<Movie> Movies { get; set; } = null!;
}
