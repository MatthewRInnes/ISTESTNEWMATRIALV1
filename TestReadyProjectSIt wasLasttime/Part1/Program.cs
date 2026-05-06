// Brings in Entity Framework Core so we can build DbContext options and query the database.
using Microsoft.EntityFrameworkCore;
// Brings my application namespace into scope (entity and DbContext types live there).
using NewsSites;

// Prints my name on the first line of output (typical coursework header).
Console.WriteLine("Matthew Innes");
// Prints my student or candidate ID on the second line of output.
Console.WriteLine("B01841977");

// Fixed file name for the SQLite database on disk; must match Part1.csproj and the copied .db file.
const string databaseFileName = "NewsSites.db";
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
var options = new DbContextOptionsBuilder<NewsSitesDbContext>()
    // Connection string: SQLite provider and path to the .db file (must match databasePath above).
    .UseSqlite($"Data Source={databasePath}")
    // Finishes building the options struct used by the DbContext constructor.
    .Options;

// Create the database context; 'using' ensures it is disposed when the block ends (frees native connections).
using var db = new NewsSitesDbContext(options);

// Prompt the user to type a platform name to look up.
Console.Write("Enter a Job name: ");
// Read a line from the console, remove leading/trailing spaces, or use an empty string if the user only pressed Enter.
// NOTE: This is my INPUT VARIABLE (what the User types). The variable name in C# can be anything.
var inputName = Console.ReadLine()?.Trim() ?? string.Empty;

// Query: find one row whose Name equals the typed text, ignoring upper/lower case differences.
var match = await db.NewsSites
    // Do not track entities in the change tracker (read-only lookup; slightly lighter).
    .AsNoTracking()
    // IMPORTANT:
    // - c.Name is the *database value* (it maps to the NewsSites table column called "Name").
    // - inputName is the input variable(Its only used in this file and matches var inputName = Console.ReadLine()?.Trim() ?? string.Empty; above and {inputName} below)
    // This comparison keeps rows where the database Name matches the typed name (ignoring upper/lower case).
    .Where(c => c.Name.ToLower() == inputName.ToLower())
    // Return the first matching row, or null if nothing matched (asynchronously).
    .FirstOrDefaultAsync();

// Branch when nothing matched the search text.
if (match is null)
{
    // Explain that no row had that name (including empty search).
    Console.WriteLine($"No URL found for '{inputName}'.");
}
else
{
    // Show the stored Name and Url from the row we found.
    Console.WriteLine($"The URL for {match.Name} is {match.Url}");
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
