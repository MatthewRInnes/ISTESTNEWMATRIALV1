using Microsoft.EntityFrameworkCore;
using MusicPlatforms;

// Student header — change if your tutor expects different details.
Console.WriteLine("Matthew Innes");
Console.WriteLine("B01841977");

// Locate MusicPlatforms.db beside the built exe (bin/Debug/net8.0 when you press F5).
const string databaseFileName = "MusicPlatforms.db";
var databasePath = Path.Combine(AppContext.BaseDirectory, databaseFileName);

if (!File.Exists(databasePath))
{
    Console.WriteLine($"Database file not found: {databasePath}");
    Console.WriteLine("Build the project; ensure MusicPlatforms.db exists or create it from MusicPlatforms.sql.");
    return;
}

// SQLite connection — same pattern as TechForums Part 1.
var options = new DbContextOptionsBuilder<MusicPlatformsDbContext>()
    .UseSqlite($"Data Source={databasePath}")
    .Options;

await using var db = new MusicPlatformsDbContext(options);

// *** Practise line for this folder only: alphabetical by platform name (A–Z). ***
var rows = await db.MusicPlatforms
    .AsNoTracking()
    .OrderBy(x => x.Name)
    .ToListAsync();

Console.WriteLine("Ordered by Name ascending (A–Z):\n");
foreach (var r in rows)
    Console.WriteLine($"{r.Name,-18} | {r.Url}");

Console.WriteLine();
Console.WriteLine("Press any key to exit.");
if (!Console.IsInputRedirected)
{
    Console.ReadKey(intercept: true);
}
