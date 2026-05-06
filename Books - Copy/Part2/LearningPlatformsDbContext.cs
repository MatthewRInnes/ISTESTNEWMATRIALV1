using Microsoft.EntityFrameworkCore; // EF Core library that lets the web app query SQLite.

namespace Books; // MUST match the namespace in `LearningSite.cs` (Book) and `Pages/Index.cshtml.cs`.

// FILE TYPE: DbContext for the web app.
// WHAT IT IS: `BooksDbContext` is the “database connection + query helper” class.
// WHAT IT IS NOT: it is NOT a table row; the entity class (`Book`) is the table row.
public sealed class BooksDbContext : DbContext
{
    // CONSTRUCTOR: dependency injection passes configuration in here.
    // MUST match this Program.cs line: `builder.Services.AddDbContext<BooksDbContext>(...)`
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {
    }

    // DbSet = “table” as a C# collection.
    // MUST match these example lines elsewhere:
    // - Index.cshtml.cs query starts: `_db.Books`
    // - Entity table mapping: LearningSite.cs has `[Table("Books")]`
    public DbSet<Book> Books { get; set; } = null!;
}
