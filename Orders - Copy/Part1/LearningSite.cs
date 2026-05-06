// PROBLEM: these two `using` lines are wrong, so C# cannot find [Key], [Required], [Table], [Column].
// They must come from the real .NET namespaces:
// - `using System.ComponentModel.DataAnnotations;`
// - `using System.ComponentModel.DataAnnotations.Schema;`
// Right now you have `ComponentModelt` instead of `ComponentModel`, which causes the build errors.
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Namespace shared by the entity and DbContext in this Part 1 project (matches Part1.csproj RootNamespace).
namespace Orders;

// Maps this class to the SQL table named in [Table(...)] (must match CREATE TABLE in my schema script).
[Table("Orders")]
// One row represents one record from that table (one logical item my app stores).
public class Order
{
    // Marks ID as the primary key for EF Core.
    [Key]
    // CLR property ID maps to the SQL column named "ID".
    [Column("ID")]
    // Auto-increment integer primary key from the database.
    public int ID { get; set; }

    // Value cannot be null when saving (matches NOT NULL in SQL).
    [Required]
    // This must match the SQL column name in Orders.sql: `CustomerName TEXT NOT NULL`.
    [Column("CustomerName")]
    // Student's Full name (used for searching and display).
    public string CustomerName { get; set; } = string.Empty;

    // Order total amount.
    [Column("TotalAmount")]
    public decimal TotalAmount { get; set; }

    // Url text cannot be null when saving (matches NOT NULL in SQL).
    [Required]
    // This must match the SQL column name in Orders.sql: `OrdersURL TEXT NOT NULL`.
    [Column("OrdersURL")]
    // Full web address shown after a successful lookup.
    public string OrdersUrl { get; set; } = string.Empty;
}
