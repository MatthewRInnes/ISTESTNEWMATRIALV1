using Microsoft.EntityFrameworkCore; // EF Core library that lets the web app query SQLite.

namespace Orders; // Same project namespace as `LearningSite.cs` (Order) and `Pages/Index.cshtml.cs`.

// FILE TYPE: DbContext for the web app.
// WHAT IT IS: `OrdersDbContext` is the “database connection + query helper” class.
// WHAT IT IS NOT: it is NOT a table row; the entity class (`Order`) is the table row.
public sealed class OrdersDbContext : DbContext
{
    // CONSTRUCTOR: dependency injection passes configuration in here.
    // Same DbContext type as Program.cs registers:
    // `builder.Services.AddDbContext<OrdersDbContext>(...)`
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
    {
    }

    // DbSet = “table” as a C# collection.
    // Used like this in code:
    // - Index.cshtml.cs query starts: `_db.Orders`
    // - SQL table name is in the entity mapping: LearningSite.cs has `[Table("Orders")]`
    //   (same as `CREATE TABLE Orders` in Orders.sql)
    public DbSet<Order> Orders { get; set; } = null!;
}
