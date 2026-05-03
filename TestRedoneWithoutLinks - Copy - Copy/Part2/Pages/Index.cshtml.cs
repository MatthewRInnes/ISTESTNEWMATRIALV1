// Razor Pages base type (PageModel, HTTP context, handlers).
using Microsoft.AspNetCore.Mvc.RazorPages;
// Async LINQ for EF queries (AsNoTracking, OrderBy, ToListAsync).
using Microsoft.EntityFrameworkCore;
// My DbContext and Channel entity types.
using StreamingSites;

// Namespace must match @namespace in Index.cshtml so Razor binds to this PageModel.
namespace StreamingSites.Pages;

// Code-behind for the home page; loads channel rows before the view renders.
public class IndexModel : PageModel
{
    // Database context injected by ASP.NET Core when the page is constructed.
    private readonly StreamingSitesDbContext _db;

    // Constructor receives the scoped DbContext instance from DI.
    public IndexModel(StreamingSitesDbContext db)
    {
        // Store for use inside OnGetAsync.
        _db = db;
    }

    // Collection the Razor page binds to (same member name as Model.Channels in Index.cshtml).
    public List<Channel> Channels { get; private set; } = [];

    // Runs for HTTP GET to this page’s route (typically the site root).
    public async Task OnGetAsync()
    {
        // Load all rows from my Channels DbSet, sorted for display.
        Channels = await _db.Channels
            // Read-only: no change tracker overhead for a simple list.
            .AsNoTracking()
            // Alphabetical order by the Name column.
            .OrderBy(c => c.Name)
            // Execute asynchronously and materialise a list.
            .ToListAsync();
    }
}
