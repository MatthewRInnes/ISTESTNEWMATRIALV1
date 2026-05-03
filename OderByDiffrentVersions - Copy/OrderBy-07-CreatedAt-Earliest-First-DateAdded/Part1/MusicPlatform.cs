using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicPlatforms;

// Entity maps to table MusicPlatforms — same three columns as TechForums (ID, Name, URL).
[Table("MusicPlatforms")]
public class MusicPlatform
{
    // Primary key column ID in SQL — matches INSERT auto IDs.
    [Key]
    [Column("ID")]
    public int ID { get; set; }

    // Platform display name — used in OrderBy on Name.
    [Required]
    [Column("Name")]
    public string Name { get; set; } = string.Empty;

    // Full URL string — used when sorting by link text order.
    [Required]
    [Column("URL")]
    public string Url { get; set; } = string.Empty;
}
