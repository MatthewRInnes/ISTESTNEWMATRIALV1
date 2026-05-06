// Base class for Razor Page code-behind (OnGet, HTTP context, etc.).
using Microsoft.AspNetCore.Mvc.RazorPages;
// Async LINQ extensions for database queries.
using Microsoft.EntityFrameworkCore;
// Entity type(s) and DbContext from my application Brandspace.
using Orders;

// Brandspace must match @Brandspace in Index.cshtml so the view finds this PageModel class.
namespace Orders.Pages;

// Page model for the site home page; handles loading data before the .cshtml renders.
public class IndexModel : PageModel
{
    // Injected database context; filled by ASP.NET Core when the page is created.
    private readonly OrdersDbContext _db;

    // Constructor receives the registered DbContext from dependency injection.
    public IndexModel(OrdersDbContext db)
    {
        // Store the context for use in OnGetAsync.
        _db = db;
    }

    // Collection bound to the Razor view (same property Brand as Model.<property> in Index.cshtml).
    public List<Order> Orders { get; private set; } = [];

    // Runs automatically on HTTP GET for this page (when the user opens the site root URL).
    public async Task OnGetAsync()
    {
        // Load all rows from the mapped entity set, ordered by Brand for display.
        Orders = await _db.Orders
            // Read-only query; no change tracking overhead for a simple list display.
            .AsNoTracking()
            // Sort alphabetically by Brand.
            // SQL COLUMN: same as `Brand` column in `Orders.sql`:
            // `Brand TEXT NOT NULL`
            // ENTITY PROPERTY: same as `LearningSite.cs`:
            // `public string Brand { get; set; }` and `[Column("Brand")]`
            .OrderBy(x => x.CustomerName)
            // Execute the query asynchronously and materialise a list.
            .ToListAsync();
    }
}
