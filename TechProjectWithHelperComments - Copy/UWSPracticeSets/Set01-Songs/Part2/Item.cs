using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Set01.Songs.Part2;

// This class represents one row in the database table.
// The names in [Table] and [Column] MUST match the database.
[Table("Channels")]
public class Item
{
    // This must match the ID column in the database.
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    // This must match the “text/name” column in the database.
    [Required]
    [Column("Name")]
    public string Text { get; set; } = string.Empty;

    // This must match the “link/url” column in the database.
    [Required]
    [Column("URL")]
    public string Url { get; set; } = string.Empty;
}
