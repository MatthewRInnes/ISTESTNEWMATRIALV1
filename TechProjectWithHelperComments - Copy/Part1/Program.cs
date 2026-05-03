using Microsoft.EntityFrameworkCore;
using TechForums; // must match namespace TechForums in TechForumsDbContext.cs and LearningSite.cs

Console.WriteLine("Matthew Innes");
Console.WriteLine("B01841977");

const string databaseFileName = "TechForums.db"; // must match Part1.csproj <None Update="TechForums.db"> and the file on disk — example: <None Update="TechForums.db">
var databasePath = Path.Combine(AppContext.BaseDirectory, databaseFileName); // runtime folder is bin/Debug/net8.0 when you F5

if (!File.Exists(databasePath))
{
    Console.WriteLine($"Database file not found: {databasePath}");
    Console.WriteLine("Build the project; ensure TechForums.db exists in the project folder (or create it from TechForums.sql).");
    return;
}

var options = new DbContextOptionsBuilder<TechForumsDbContext>() // generic must match class TechForumsDbContext in TechForumsDbContext.cs
    .UseSqlite($"Data Source={databasePath}") // same path as databasePath — example: Data Source=…\\TechForums.db
    .Options;

using var db = new TechForumsDbContext(options); // must match public TechForumsDbContext(DbContextOptions<TechForumsDbContext> options) in TechForumsDbContext.cs

Console.Write("Enter a platform name: ");
var Name = Console.ReadLine()?.Trim() ?? string.Empty; // local variable; does not have to match a C# type name

var match = await db.TechForums // must match public DbSet<LearningSite> TechForums in TechForumsDbContext.cs (property is TechForums)
    .AsNoTracking()
    .Where(c => c.Name.ToLower() == Name.ToLower()) // c.Name must match public string Name on LearningSite in LearningSite.cs
    .FirstOrDefaultAsync();

if (match is null)
{
    Console.WriteLine($"No URL found for '{Name}'.");
}
else
{
    Console.WriteLine($"The URL for {match.Name} is {match.Url}"); // Name and Url must match properties on LearningSite in LearningSite.cs
}

Console.WriteLine();
Console.WriteLine("Press any key to exit.");
if (!Console.IsInputRedirected)
{
    Console.ReadKey(intercept: true);
}
