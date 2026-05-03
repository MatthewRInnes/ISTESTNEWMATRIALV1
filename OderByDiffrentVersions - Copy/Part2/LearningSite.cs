using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningPlatforms; // must match Part2.csproj <RootNamespace> and LearningPlatformsDbContext.cs

[Table("LearningSites")] // must match CREATE TABLE LearningSites in Part2/LearningPlatforms.sql
public class LearningSite // must match DbSet<LearningSite> in LearningPlatformsDbContext.cs — example: public DbSet<LearningSite> LearningSites
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
