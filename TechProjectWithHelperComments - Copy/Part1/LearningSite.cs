using System.ComponentModel.DataAnnotations; // [Key], [Required], …
using System.ComponentModel.DataAnnotations.Schema; // [Table], [Column]

namespace TechForums; // must match Part1.csproj <RootNamespace> and OnlineStoreDbContext.cs — example: <RootNamespace>OnlineStore</RootNamespace>

[Table("TechForums")] // must match CREATE TABLE OnlineStore in OnlineStore.sql — example: CREATE TABLE OnlineStore (
public class TechForum // must match DbSet<LearningSite> in OnlineStoreDbContext.cs — example: public DbSet<LearningSite> OnlineStore
{
    [Key]
    [Column("ID")] // must match SQL column ID in OnlineStore.sql
    public int ID { get; set; }

    [Required]
    [Column("Name")] // must match SQL column Name; Program.cs uses c.Name — example: .Where(c => c.Name …)
    public string Name { get; set; } = string.Empty;

    [Required]
    [Column("URL")] // must match SQL column URL; C# property Url — example: match.Url in Program.cs
    public string Url { get; set; } = string.Empty;
}
