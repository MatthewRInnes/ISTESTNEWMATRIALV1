// Base class for Razor Page code-behind (OnGet, HTTP context, etc.).
using Microsoft.AspNetCore.Mvc.RazorPages;
// Async LINQ extensions for database queries.
using Microsoft.EntityFrameworkCore;
// Entity type(s) and DbContext from my application namespace.
using TechForums;

// Namespace must match @namespace in Index.cshtml so the view finds this PageModel class.
namespace TechForums.Pages;

// Page model for the site home page; handles loading data before the .cshtml renders.
public class IndexModel : PageModel
{
    // Injected database context; filled by ASP.NET Core when the page is created.
    private readonly TechForumsDbContext _db;

    // Constructor receives the registered DbContext from dependency injection.
    public IndexModel(TechForumsDbContext db)
    {
        // Store the context for use in OnGetAsync.
        _db = db;
    }

    // Collection bound to the Razor view (same property name as Model.<property> in Index.cshtml).
    public List<TechForum> TechForums { get; private set; } = [];

    // Runs automatically on HTTP GET for this page (when the user opens the site root URL).
    public async Task OnGetAsync()
    {
        // Load all rows from the mapped entity set, ordered by name for display.
        TechForums = await _db.TechForums
            // Read-only query; no change tracking overhead for a simple list display.
            .AsNoTracking()
            // Sort alphabetically by the Name column (case-sensitive behaviour depends on SQLite collation).
            .OrderBy(x => x.Name)
            // Execute the query asynchronously and materialise a list.
            .ToListAsync();
    }
}
