using Microsoft.EntityFrameworkCore;
using MusicPlatforms; // must match namespace in MusicPlatformsDbContext.cs and MusicPlatforms.cs

Console.WriteLine("Matthew Innes");
Console.WriteLine("B01841977");

// .db filename: YOU pick it; must match Part1.csproj <None Update="…"> and this string — it does not have to match a table name — example: <None Update="MusicPlatforms.db">
const string databaseFileName = "MusicPlatforms.db";
var databasePath = Path.Combine(AppContext.BaseDirectory, databaseFileName);

if (!File.Exists(databasePath))
{
    Console.WriteLine($"Database file not found: {databasePath}");
    Console.WriteLine("Build the project; add MusicPlatforms.db to the project folder (create from MusicPlatforms.sql if needed).");
    return;
}

// MusicPlatformsDbContext: must match public sealed class MusicPlatformsDbContext in MusicPlatformsDbContext.cs
var options = new DbContextOptionsBuilder<MusicPlatformsDbContext>()
    .UseSqlite($"Data Source={databasePath}")
    .Options;

using var db = new MusicPlatformsDbContext(options);

Console.Write("Enter a platform name: ");
var Name = Console.ReadLine()?.Trim() ?? string.Empty; // local name; no need to match SQL

// db.MusicPlatforms: must match DbSet property name MusicPlatforms on MusicPlatformsDbContext; each row is type MusicPlatform — example: public DbSet<MusicPlatform> MusicPlatforms
var match = await db.MusicPlatforms
    .AsNoTracking()
    .Where(c => c.Name.ToLower() == Name.ToLower()) // c is a MusicPlatform; c.Name is the property in MusicPlatforms.cs
    .FirstOrDefaultAsync();

if (match is null)
    Console.WriteLine($"No URL found for '{Name}'.");
else
    Console.WriteLine($"The URL for {match.Name} is {match.Url}"); // match is MusicPlatform from MusicPlatforms.cs

Console.WriteLine();
Console.WriteLine("Press any key to exit.");
if (!Console.IsInputRedirected)
    Console.ReadKey(intercept: true);
