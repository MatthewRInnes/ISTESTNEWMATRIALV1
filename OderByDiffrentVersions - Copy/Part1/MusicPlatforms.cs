using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicPlatforms; // YOU choose this; must match Part1.csproj <RootNamespace> and MusicPlatformsDbContext.cs — not read from the database file

[Table("MusicPlatforms")] // THIS ties C# to SQL: must match CREATE TABLE MusicPlatforms in MusicPlatforms.sql — example: CREATE TABLE MusicPlatforms (
public class MusicPlatform // MUST MATCH spelling inside DbSet<MusicPlatform> in MusicPlatformsDbContext.cs — example: public DbSet<MusicPlatform> MusicPlatforms
{
    [Key]
    [Column("ID")] // FROM SQL: column name must match MusicPlatforms.sql — example: ID INTEGER PRIMARY KEY …
    public int ID { get; set; }

    [Required]
    [Column("Name")] // FROM SQL column Name — Program.cs uses c.Name only because this property is called Name
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("URL")] // FROM SQL column URL — C# uses Url; mapping links them — example: [Column("URL")] public string Url
    public string Url { get; set; } = string.Empty;
}
