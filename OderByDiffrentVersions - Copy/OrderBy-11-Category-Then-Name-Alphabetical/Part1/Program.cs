using Microsoft.EntityFrameworkCore;
using MusicPlatforms;

Console.WriteLine("Matthew Innes");
Console.WriteLine("B01841977");

const string databaseFileName = "MusicPlatforms.db";
var databasePath = Path.Combine(AppContext.BaseDirectory, databaseFileName);

if (!File.Exists(databasePath))
{
    Console.WriteLine($"Database file not found: {databasePath}");
    Console.WriteLine("Build the project; ensure MusicPlatforms.db exists or create it from MusicPlatforms.sql.");
    return;
}

var options = new DbContextOptionsBuilder<MusicPlatformsDbContext>()
    .UseSqlite($"Data Source={databasePath}")
    .Options;

await using var db = new MusicPlatformsDbContext(options);

// *** Folder name is legacy — practise Name Z–A with URL as secondary sort. ***
var rows = await db.MusicPlatforms
    .AsNoTracking()
    .OrderByDescending(x => x.Name)
    .ThenBy(x => x.Url)
    .ToListAsync();

Console.WriteLine("Ordered by Name descending, then URL ascending:\n");
foreach (var r in rows)
    Console.WriteLine($"{r.Name,-18} | {r.Url}");

Console.WriteLine();
Console.WriteLine("Press any key to exit.");
if (!Console.IsInputRedirected)
{
    Console.ReadKey(intercept: true);
}
