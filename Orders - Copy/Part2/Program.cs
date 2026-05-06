// EF Core for registering DbContext with the dependency injection container.
using Microsoft.EntityFrameworkCore;
// PROBLEM: this Part2 project is wired to the *Orders* example, not Orders.
// If this is meant to be Orders Part2, the namespace here should match your Orders entity/DbContext (e.g. `using Orders;`)
// and the DB should be Orders.db / Orders.sql, not Orders.db.
using Orders;

// Builds configuration, logging, and the web host (reads appsettings and launch profiles).
var builder = WebApplication.CreateBuilder(args);

// Registers Razor Pages services so .cshtml pages can use PageModel classes.
builder.Services.AddRazorPages();

// Registers my DbContext so page models receive it via constructor injection; SQLite file sits beside the built output.
// PROBLEM: DbContext type is OrdersDbContext (Orders project). Orders Part2 should be OrdersDbContext.
builder.Services.AddDbContext<OrdersDbContext>(options =>
    // Filename here must match Part2.csproj “Copy to output” and the file on disk.
    // PROBLEM: this points at Orders.db. Orders Part2 should point at Orders.db (and copy it in the .csproj).
    options.UseSqlite("Data Source=Orders.db"));

// Builds the WebApplication pipeline object from the configured builder.
var app = builder.Build();

// In staging/production, use friendly error pages and strict transport security instead of detailed exceptions.
if (!app.Environment.IsDevelopment())
{
    // Sends errors to a Razor route named Error (optional page not shown here).
    app.UseExceptionHandler("/Error");
    // Adds HTTP Strict Transport Security headers for HTTPS clients.
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS where appropriate.
app.UseHttpsRedirection();
// Enables serving files from wwwroot (CSS, JS, images).
app.UseStaticFiles();
// Enables routing so URLs map to endpoints and Razor Pages.
app.UseRouting();
// Registers Razor Page endpoints; / maps to Pages/Index.cshtml when that file has @page at the top.
app.MapRazorPages();

// Starts the web server and blocks until the process shuts down.
app.Run();
