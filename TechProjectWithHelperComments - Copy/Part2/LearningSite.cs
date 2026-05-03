using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechForums; // must match Part2.csproj <RootNamespace> and TechForumsDbContext.cs

[Table("TechForums")] // must match CREATE TABLE TechForums in Part2/TechForums.sql
public class TechForum // must match DbSet<TechForum> in TechForumsDbContext.cs — example: public DbSet<TechForum> TechForums
{
    [Key]
    [Column("ID")] // must match SQL column ID
    public int ID { get; set; }

    [Required]
    [Column("Name")] // must match Index.cshtml.cs .OrderBy(x => x.Name)
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("URL")] // must match @site.Url in Index.cshtml
    public string Url { get; set; } = string.Empty;
}
