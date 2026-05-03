// Entity Framework Core: database provider registration and extension methods.
using Microsoft.EntityFrameworkCore;
// Brings my application types (DbContext and entity model) into scope.
using StreamingSites;

// Web host entry point: builds configuration, services, and the HTTP pipeline for the site.
var builder = WebApplication.CreateBuilder(args);
// Reads command-line args, environment, and appsettings; prepares dependency injection and logging.

// Registers Razor Pages so .cshtml files under Pages/ become routable endpoints.
builder.Services.AddRazorPages();

// Register my DbContext with DI; SQLite file name must match the string in UseSqlite and sit beside the build output.
builder.Services.AddDbContext<StreamingSitesDbContext>(options =>
    // Connection string: SQLite and on-disk file created next to the published or debug output.
    options.UseSqlite("Data Source=StreamingSites.db"));

// Construct the WebApplication from the configured builder (middleware not yet fully configured).
var app = builder.Build();

// At startup, ensure the database and seed data exist so the site runs without a pre-copied .db.
using (var scope = app.Services.CreateScope())
// A scope is required to resolve scoped services (DbContext) outside an HTTP request.
{
    // Resolve my registered DbContext from the service provider for this scope.
    var db = scope.ServiceProvider.GetRequiredService<StreamingSitesDbContext>();

    // Create the database and tables from the EF model if they are missing.
    db.Database.EnsureCreated();

    // If the mapped table has no rows yet, insert the sample data once (avoids duplicating on every run).
    if (!db.Channels.Any())
    {
        // Add several seed Channel rows (names only; this project omits URL links).
        db.Channels.AddRange(
        [
            new Channel { Name = "Netflix" },
            new Channel { Name = "YouTube" },
            new Channel { Name = "Disney+" },
            new Channel { Name = "Discovery+" },
            new Channel { Name = "Apple TV" }
        ]);

        // Write the new rows to the SQLite file.
        db.SaveChanges();
    }
}

// Outside Development, use production-style error handling and HSTS.
if (!app.Environment.IsDevelopment())
{
    // Route unhandled exceptions to a generic error page (not used in this minimal sample).
    app.UseExceptionHandler("/Error");
    // Instruct supporting browsers to prefer HTTPS for this host.
    app.UseHsts();
}

// Redirect plain HTTP requests to HTTPS when appropriate.
app.UseHttpsRedirection();
// Enable static file middleware for wwwroot (if I add assets later).
app.UseStaticFiles();
// Enable URL routing to match endpoints to Razor Pages.
app.UseRouting();
// Register endpoints for all Razor Pages; the site root maps to Pages/Index.cshtml when it has @page.
app.MapRazorPages();

// Start Kestrel; blocks until the process is stopped.
app.Run();
