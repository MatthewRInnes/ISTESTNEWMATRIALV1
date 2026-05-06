// EF Core (for registering the DbContext and SQLite provider).
using Microsoft.EntityFrameworkCore;
// Imports your project types (StudentsDbContext / Student).
using Students;

// Creates the web app builder (configuration + services).
var builder = WebApplication.CreateBuilder(args);

// Enables Razor Pages (Pages/*.cshtml + PageModel code-behind).
builder.Services.AddRazorPages();

// Registers the DbContext so PageModels can query the SQLite database.
builder.Services.AddDbContext<StudentsDbContext>(options =>
    // Tells EF Core to use SQLite and which database file to open.
    options.UseSqlite("Data Source=Students.db"));

// Builds the app (middleware pipeline + endpoints).
var app = builder.Build();

// Uses production-style error handling outside Development.
if (!app.Environment.IsDevelopment())
{
    // Redirects unhandled errors to an error page.
    app.UseExceptionHandler("/Error");
    // Adds HSTS headers (security).
    app.UseHsts();
}

// Redirects HTTP to HTTPS (when HTTPS is configured).
app.UseHttpsRedirection();
// Enables static files from `wwwroot` (if present).
app.UseStaticFiles();
// Enables endpoint routing.
app.UseRouting();
// Maps Razor Pages endpoints (e.g., `/` -> `Pages/Index.cshtml`).
app.MapRazorPages();

// Starts the web server.
app.Run();
