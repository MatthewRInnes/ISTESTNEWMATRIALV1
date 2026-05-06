// Attributes that mark required fields and keys on entity classes.
using System.ComponentModel.DataAnnotations;
// Attributes that map CLR properties to SQL table and column names.
using System.ComponentModel.DataAnnotations.Schema;

// Namespace shared by the entity and DbContext in this Part 1 project (matches Part1.csproj RootNamespace).
namespace Books;

// Maps this class to the SQL table named in [Table(...)] (must match CREATE TABLE in my schema script).
[Table("Books")]
// One row represents one record from that table (one logical item my app stores).
public class Book
{
    // Marks ID as the primary key for EF Core.
    [Key]
    // CLR property ID maps to the SQL column named "ID".
    [Column("ID")]
    // Auto-increment integer primary key from the database.
    public int ID { get; set; }

    // Value cannot be null when saving (matches NOT NULL in SQL).
    [Required]
    // SQL COLUMN: same as column `Title` in `Books.sql`:
    // `Title TEXT NOT NULL`
    [Column("Title")]
    // Student's Full name (used for searching and display).
    public string Title { get; set; } = string.Empty;

    // SQL COLUMN: same as column `Author` in `Books.sql`:
    // `Author TEXT NOT NULL`
    [Column("Author")]
    // Author is TEXT in SQL, so this must be a string in C#.
    public string Author { get; set; } = string.Empty;

    // Url text cannot be null when saving (matches NOT NULL in SQL).
    [Required]
    // SQL column mapping for the Amazon link.
    [Column("AmazonURL")]
    // Full web address shown after a successful lookup.
    public string AmazonUrl { get; set; } = string.Empty;
}
