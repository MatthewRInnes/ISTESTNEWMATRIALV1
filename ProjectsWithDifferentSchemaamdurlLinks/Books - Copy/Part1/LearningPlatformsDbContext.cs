using Microsoft.EntityFrameworkCore; // EF Core library that lets C# talk to SQLite.

namespace Books; // MUST match the namespace in `LearningSite.cs` (so Student + BooksDbContext are in the same project namespace).

// `BooksDbContext` = your “database connection + query helper” class.
// You do NOT guess data field names here; it just exposes the table(s) you can query.
public sealed class BooksDbContext : DbContext
{
    // EF passes configuration in here (database provider + connection string).
    // MUST match the type used in Program.cs: `new DbContextOptionsBuilder<BooksDbContext>()`.
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {
    }

    // `DbSet<Student>` means “the Books table as C# objects”.
    // MUST match these example lines elsewhere:
    // - Program.cs query starts: `db.Books`
    // - SQL table name lives in the entity: LearningSite.cs has `[Table("Books")]`
    public DbSet<Book> Books { get; set; } = null!;
}
