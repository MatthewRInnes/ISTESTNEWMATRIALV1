// Validation and key attributes for entity properties.
using System.ComponentModel.DataAnnotations;
// Map CLR names to SQL table and column names.
using System.ComponentModel.DataAnnotations.Schema;

// Root namespace for my Part 2 code; must match Part2.csproj and my DbContext file.
namespace StreamingSites;

// One entity instance = one row in the table named in [Table(...)]; must match my CREATE TABLE script.
[Table("Channels")]
// Holds a single streaming channel display name (no URL in this version of the project).
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
    // Text shown in the list on the home page; initialised to empty to avoid null reference issues in C#.
    public string Name { get; set; } = string.Empty;
}
