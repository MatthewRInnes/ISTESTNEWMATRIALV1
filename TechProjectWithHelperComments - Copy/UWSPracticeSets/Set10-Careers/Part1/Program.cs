using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Set10.Careers.Part1;

// --- Your details (the test normally asks for these) ---
Console.WriteLine("Matthew Innes");
Console.WriteLine("B01841977");
Console.WriteLine();

// --- File names that must match real files ---
const string databaseFileName = "Careers.db";
const string sqlFileName = "Careers.sql";

// --- Build the full paths in the program’s folder ---
var databasePath = Path.Combine(AppContext.BaseDirectory, databaseFileName);
var sqlPath = Path.Combine(AppContext.BaseDirectory, sqlFileName);

// --- If the database is missing, create it using the .sql script ---
if (!File.Exists(databasePath))
{
    if (!File.Exists(sqlPath))
    {
        Console.WriteLine($"Missing SQL script: {sqlPath}");
        Console.WriteLine("Build the project again so the .sql is copied over.");
        return;
    }

    var sql = await File.ReadAllTextAsync(sqlPath);

    using var connection = new SqliteConnection($"Data Source={databasePath}");
    await connection.OpenAsync();

    using var command = connection.CreateCommand();
    command.CommandText = sql;
    await command.ExecuteNonQueryAsync();
}

// --- Tell EF Core how to open the SQLite file ---
var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite($"Data Source={databasePath}")
    .Options;

// --- Open the database and ask the user what to search for ---
using var db = new AppDbContext(options);

Console.Write("Enter a Careers name to search for: ");
var userText = Console.ReadLine()?.Trim() ?? string.Empty;

// --- This is the important “must match” bit ---
// What you type (userText) must match what is stored in the database column: Name
var match = await db.Items
    .AsNoTracking()
    .FirstOrDefaultAsync(i => i.Text.ToLower() == userText.ToLower());

// --- Print the result ---
if (match is null)
{
    Console.WriteLine($"No match found for '{userText}'.");
}
else
{
    Console.WriteLine($"Name: {match.Text}");
    Console.WriteLine($"Link: {match.Url}");
}

Console.WriteLine();
Console.WriteLine("Press any key to exit.");
if (!Console.IsInputRedirected)
{
    Console.ReadKey(intercept: true);
}
