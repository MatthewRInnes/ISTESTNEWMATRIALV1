// EF Core: DbContextOptionsBuilder, UseSqlite, and async query extensions.
using Microsoft.EntityFrameworkCore;
// My Channel entity and StreamingSitesDbContext types.
using StreamingSites;

// Prints my name on the first line of output (coursework header).
Console.WriteLine("Matthew Innes");
// Prints my student ID on the second line.
Console.WriteLine("B01841977");

// Same SQLite filename as Part 2 so behaviour matches; each project still uses its own output folder unless I share a path.
const string databaseFileName = "StreamingSites.db";
// Full path next to the built exe (e.g. bin/Debug/net8.0).
var databasePath = Path.Combine(AppContext.BaseDirectory, databaseFileName);

// Options for SQLite pointing at my local database file.
var options = new DbContextOptionsBuilder<StreamingSitesDbContext>()
    .UseSqlite($"Data Source={databasePath}")
    .Options;

// Context lifetime for this console run; disposed at end of scope.
await using var db = new StreamingSitesDbContext(options);

// Create database file and Channels table from my EF model if they do not exist yet (same idea as Part 2 startup).
await db.Database.EnsureCreatedAsync();

// Seed sample rows once if the table is empty — same names as Part 2 (no URLs anywhere).
if (!await db.Channels.AnyAsync())
{
    db.Channels.AddRange(
    [
        new Channel { Name = "Netflix" },
        new Channel { Name = "YouTube" },
        new Channel { Name = "Disney+" },
        new Channel { Name = "Discovery+" },
        new Channel { Name = "Apple TV" }
    ]);
    await db.SaveChangesAsync();
}

// Load channels sorted by name, same ordering as Part 2 Index page (read-only query).
var channels = await db.Channels
    .AsNoTracking()
    .OrderBy(c => c.Name)
    .ToListAsync();

// Heading makes clear this Part 1 output is plain text only — no clickable links in the terminal.
Console.WriteLine();
Console.WriteLine("Streaming site names (alphabetical, text only — no links):");

// Print each name on its own line; nothing here is wrapped in HTML anchors (contrast with optional linked lists elsewhere).
foreach (var ch in channels)
{
    Console.WriteLine($"  {ch.Name}");
}

Console.WriteLine();
Console.WriteLine("Press any key to exit.");
if (!Console.IsInputRedirected)
{
    Console.ReadKey(intercept: true);
}
