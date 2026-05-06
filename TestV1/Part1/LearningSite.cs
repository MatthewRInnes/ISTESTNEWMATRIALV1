// Attributes that mark required fields and keys on entity classes.
using System.ComponentModel.DataAnnotations;
// Attributes that map CLR properties to SQL table and column names.
using System.ComponentModel.DataAnnotations.Schema;

// Namespace shared by the entity and DbContext in this Part 1 project (matches Part1.csproj RootNamespace).
namespace NewsSites;

// Maps this class to the SQL table named in [Table(...)] (must match CREATE TABLE in my schema script).
[Table("NewsSites")]
// One row represents one record from that table (one logical item my app stores).
public class NewsSite
{
    // Marks ID as the primary key for EF Core.
    [Key]
    // CLR property ID maps to the SQL column named "ID".
    [Column("ID")]
    // Auto-increment integer primary key from the database.
    public int ID { get; set; }

    // Value cannot be null when saving (matches NOT NULL in SQL).
    [Required]
    // CLR property Name maps to the SQL column named "Name".
    [Column("Name")]
    // Platform display name used in WHERE filters and console output.
    public string Name { get; set; } = string.Empty;

    // Url text cannot be null when saving (matches NOT NULL in SQL).
    [Required]
    // CLR property Url maps to the SQL column named "URL".
    [Column("URL")]
    // Full web address string shown after a successful lookup.
    public string Url { get; set; } = string.Empty;
}
