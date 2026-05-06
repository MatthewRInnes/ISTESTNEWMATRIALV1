// Gives access to EF Core (SQLite + async queries).
using Microsoft.EntityFrameworkCore;
// Imports your project classes (Student + StudentsDbContext).
using Students;

// Prints your name (coursework header).
Console.WriteLine("Matthew Innes");
// Prints your banner ID / candidate number (coursework header).
Console.WriteLine("B01841977");

// Name of the SQLite database file we want to open.
const string databaseFileName = "Students.db";
// Builds the full path to the database next to the running exe (bin/Debug/net8.0/...).
var databasePath = Path.Combine(AppContext.BaseDirectory, databaseFileName);

// Stops early if the database file is missing.
if (!File.Exists(databasePath))
{
    // Shows the exact path the programme tried to open.
    Console.WriteLine($"Database file not found: {databasePath}");
    // Reminder for how to fix the missing file.
    Console.WriteLine("Build the project; ensure the database file exists in the project folder (or create it from the .sql schema script).");
    // Exits the programme.
    return;
}

// Creates EF Core options telling it to use SQLite and which .db file to open.
var options = new DbContextOptionsBuilder<StudentsDbContext>()
    // Connection string: open the SQLite file at this path.
    .UseSqlite($"Data Source={databasePath}")
    // Finalises the options object.
    .Options;

// Opens the database context (and closes it automatically when we’re done).
using var db = new StudentsDbContext(options);

// Asks the user what to search for.
Console.Write("Enter a Full name: ");
// Reads user input (trimmed); becomes empty string if they just press Enter.
var FullName = Console.ReadLine()?.Trim() ?? string.Empty;

// Queries the Students table and tries to find the first row matching the typed FullName (case-insensitive).
var match = await db.Students
    // Read-only query (slightly faster than tracking).
    .AsNoTracking()
    // Filters rows to only those whose FullName matches the user input (ignoring capital letters).
    .Where(c => c.FullName.ToLower() == FullName.ToLower())
    // Attempts to fetch the first matching row (async), or null if there is no match.
    .FirstOrDefaultAsync();

// If nothing matched, show a “not found” message.
if (match is null)
{
    Console.WriteLine($"No Portfolio URL found for '{FullName}'.");
}
else
{
    // If we found a row, print the FullName and the Portfolio URL from that row.
    Console.WriteLine($"The Portfolio URL for {match.FullName} is {match.PortfolioUrl}");
}

// Blank line for readability.
Console.WriteLine();
// Tells the user how to exit.
Console.WriteLine("Press any key to exit.");
// Waits for a key press (but only when running in a real console).
if (!Console.IsInputRedirected)
{
    Console.ReadKey(intercept: true);
}
