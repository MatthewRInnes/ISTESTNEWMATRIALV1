using Microsoft.EntityFrameworkCore; // EF Core library that lets C# talk to SQLite.

namespace Orders; // MUST match the namespace in `LearningSite.cs` (so Student + OrdersDbContext are in the same project namespace).

// `OrdersDbContext` = your “database connection + query helper” class.
// You do NOT guess data field names here; it just exposes the table(s) you can query.
public sealed class OrdersDbContext : DbContext
{
    // EF passes configuration in here (database provider + connection string).
    // MUST match the type used in Program.cs: `new DbContextOptionsBuilder<OrdersDbContext>()`.
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
    {
    }

    // COMMENT PROBLEM: this says `DbSet<Student>` but your code is `DbSet<Order>` below.
    // The correct idea is:
    // - `DbSet<Order>` = rows from SQL table `Orders` (see Orders.sql: `CREATE TABLE Orders (...)`)
    // - `db.Orders` in Program.cs queries this set
    // MUST match these example lines elsewhere:
    // - Program.cs query starts: `db.Orders`
    // - SQL table name lives in the entity: LearningSite.cs has `[Table("Orders")]`
    public DbSet<Order> Orders { get; set; } = null!;
}
