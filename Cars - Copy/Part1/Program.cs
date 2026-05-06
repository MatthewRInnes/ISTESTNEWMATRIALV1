// Brings in Entity Framework Core so we can build DbContext options and query the database.
using Microsoft.EntityFrameworkCore;
// Brings my application namespace into scope; same as `Part1.csproj` RootNamespace (`Cars`).
using Cars;

// Prints my name on the Full line of output (coursework header; this does NOT need to match the database).
Console.WriteLine("Matthew Innes");
// Prints my Brand or candidate ID on the second line of output.
Console.WriteLine("B01841977");

// SQLite DB file name; same as `Part1.csproj`:
// `<None Update="Cars.db">`
const string databaseFileName = "Cars.db";
// Full path to that file in the application’s output folder (e.g. bin/Debug/net8.0) so the app finds it at run time.
var databasePath = Path.Combine(AppContext.BaseDirectory, databaseFileName);

// If the database file is missing, we cannot run the query; tell the user and stop.
if (!File.Exists(databasePath))
{
    // Show exactly which path we looked for (helps if the .db was not copied to the output directory).
    Console.WriteLine($"Database file not found: {databasePath}");
    // Remind the user to build, place the .db, or create it from the .sql script.
    Console.WriteLine("Build the project; ensure the database file exists in the project folder (or create it from the .sql schema script).");
    // Exit early from the program; no further code in this file runs.
    return;
}

// Build the options object that tells EF Core to use SQLite and which file to open.
// DbContext type name is `CarsDbContext` (see `LearningPlatformsDbContext.cs`).
var options = new DbContextOptionsBuilder<CarsDbContext>()
    // Connection string: SQLite provider and path to the .db file (must match databasePath above).
    .UseSqlite($"Data Source={databasePath}")
    // Finishes building the options struct used by the DbContext constructor.
    .Options;

// Create the database context; 'using' ensures it is disposed when the block ends (frees native connections).
using var db = new CarsDbContext(options);

// Prompt the user to type a Full name to look up (this is just text shown to the user).
Console.Write("Enter a Full name: ");
// Read a line from the console, remove leading/trailing spaces, or use an empty string if the user only pressed Enter.
// NOTE: This is my INPUT VARIABLE (what the user types). The variable name in C# can be anything.
var Brand = Console.ReadLine()?.Trim() ?? string.Empty;

// Query: find one row whose Brand equals the typed text, ignoring upper/lower case differences.
// `db.Cars` is the DbSet for the Cars table (see `LearningPlatformsDbContext.cs`: `public DbSet<Car> Cars`).
var match = await db.Cars
    // Do not track entities in the change tracker (read-only lookup; slightly lighter).
    .AsNoTracking()
    // IMPORTANT (these 3 lines must all match each other):
    // - SQL column name: Cars.sql says `Brand TEXT NOT NULL`
    // - Entity mapping: LearningSite.cs says `[Column("Brand")] public string Brand { get; set; }`
    // - Query usage: this line must use `c.Brand`
    .Where(c => c.Brand.ToLower() == Brand.ToLower())
    // Return the Full matching row, or null if nothing matched (asynchronously).
    // PROBLEM EXPLAINED (this is why you got the error):
    // - `.FullOrDefaultAsync()` is NOT a real EF Core method, so C# says “no extension method found”.
    // - The method you usually want here is `.FirstOrDefaultAsync()` (or sometimes `.SingleOrDefaultAsync()`).
    // Example of the real method name (spelling matters):
    //   .FirstOrDefaultAsync();
    .FirstOrDefaultAsync();

// Branch when nothing matched the search text.
if (match is null)
{
    // Explain that no row had thatBrand (including empty search).
    Console.WriteLine($"No Cars URL found for '{Brand}'.");
}
else
{
    // These 2 lines must match each other:
    // - Entity property: LearningSite.cs says `public string CarsUrl { get; set; }` mapped from `[Column("CarsURL")]`
    // - SQL column name: Cars.sql says `CarsURL TEXT NOT NULL`
    Console.WriteLine($"The Cars URL for {match.Brand} is {match.CarsUrl}");
}

// Empty line for readability before the “press a key” message.
Console.WriteLine();
// Tell the user how to close the console window when running under Visual Studio / Cursor.
Console.WriteLine("Press any key to exit.");
// Only wait for a key when stdin is the real console (skips hanging in automated or piped runs).
if (!Console.IsInputRedirected)
{
    // Wait for one key press without printing it to the screen (intercept: true).
    Console.ReadKey(intercept: true);
}
