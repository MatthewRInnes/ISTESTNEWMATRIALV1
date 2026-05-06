// Attributes that mark required fields and keys on entity classes.
using System.ComponentModel.DataAnnotations;
// Attributes that map CLR properties to SQL table and column names.
using System.ComponentModel.DataAnnotations.Schema;

// Namespace shared by the entity and DbContext in this Part 1 project (matches Part1.csproj RootNamespace).
namespace Movies;

// Maps this class to the SQL table named in [Table(...)] (must match CREATE TABLE in my schema script).
[Table("Movies")]
// One row represents one record from that table (one logical item my app stores).
public class Movie
{
    // Marks ID as the primary key for EF Core.
    [Key]
    // CLR property ID maps to the SQL column named "ID".
    [Column("ID")]
    // Auto-increment integer primary key from the database.
    public int ID { get; set; }

    // Value cannot be null when saving (matches NOT NULL in SQL).
    [Required]
    // This must match the SQL column name in Movies.sql: `MovieName TEXT NOT NULL`.
    [Column("MovieName")]
    // Student's Full name (used for searching and display).
    public string MovieName { get; set; } = string.Empty;

    // This must match the SQL column name in Movies.sql: `Rating TEXT NOT NULL`.
    [Column("Rating")]
    // Rating is TEXT in SQL, so this must be a string in C#.
    public string Rating { get; set; } = string.Empty;

    // Url text cannot be null when saving (matches NOT NULL in SQL).
    [Required]
    // This must match the SQL column name in Movies.sql: `IMDbURL TEXT NOT NULL`.
    [Column("IMDbURL")]
    // Full web address shown after a successful lookup.
    public string IMDbUrl { get; set; } = string.Empty;
}
