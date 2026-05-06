using Microsoft.EntityFrameworkCore; // EF Core library that lets C# talk to SQLite.

namespace Books; // Same project namespace as `LearningSite.cs` (Book entity) and Program.cs.

// `BooksDbContext` = your “database connection + query helper” class.
// You do NOT guess data field names here; it just exposes the table(s) you can query.
public sealed class BooksDbContext : DbContext
{
    // EF passes configuration in here (database provider + connection string).
    // Same DbContext type as Program.cs builds options for:
    // `new DbContextOptionsBuilder<BooksDbContext>()`
    public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
    {
    }

    // `DbSet<Student>` means “the Books table as C# objects”.
    // Used like this in code:
    // - Program.cs query starts: `db.Books`
    // - SQL table name is in the entity mapping: LearningSite.cs has `[Table("Books")]` (same as `CREATE TABLE Books` in Books.sql)
    public DbSet<Book> Books { get; set; } = null!;
}
