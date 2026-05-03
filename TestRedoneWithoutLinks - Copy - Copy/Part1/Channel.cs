// Validation and key attributes for entity properties.
using System.ComponentModel.DataAnnotations;
// Map CLR names to SQL table and column names.
using System.ComponentModel.DataAnnotations.Schema;

// Root namespace for my Part 1 code; must match Part1.csproj and match Part 2 so both apps use the same model shape.
namespace StreamingSites;

// One entity instance = one row in the table named in [Table(...)]; must match my CREATE TABLE script.
[Table("Channels")]
// Holds a streaming channel display name only — this project does not store or print URLs.
public class Channel
{
    // Marks this property as the primary key in the model.
    [Key]
    // Binds the property to the SQL column called ID.
    [Column("ID")]
    // Integer primary key; SQLite can auto-increment when inserting new rows.
    public int ID { get; set; }

    // Disallows null in the model when the row is saved.
    [Required]
    // Binds to the Name column in the table.
    [Column("Name")]
    // Text printed in the console list; initialised to empty to avoid null reference issues in C#.
    public string Name { get; set; } = string.Empty;
}
