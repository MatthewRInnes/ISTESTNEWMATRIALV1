// PageModel (code-behind) for Index.cshtml. Loads data for the view.

// Base type for Razor Page code-behind (OnGet, HTTP context, etc.).
using Microsoft.AspNetCore.Mvc.RazorPages;
// Async query helpers for EF Core (ToListAsync, etc.).
using Microsoft.EntityFrameworkCore;
// Imports your DbContext and entity types.
using Students;

// Namespace used by the Razor view directives.
namespace Students.Pages;

// PageModel class used by the Razor view.
public class IndexModel : PageModel
{
    // DbContext used to query the database.
    private readonly StudentsDbContext _db;

    // Constructor injection: ASP.NET supplies the StudentsDbContext.
    public IndexModel(StudentsDbContext db)
    {
        // Stores the context for later use.
        _db = db;
    }

    // List of rows that the Razor view will render.
    public List<Student> Students { get; private set; } = [];

    // Runs on HTTP GET for this page.
    public async Task OnGetAsync()
    {
        // Loads all students from the database, ordered by name.
        Students = await _db.Students
            // Read-only query; avoids change tracking overhead.
            .AsNoTracking()
            // Sorts alphabetically by FullName.
            .OrderBy(x => x.FullName)
            // Executes the query and materialises the results into a List.
            .ToListAsync();
    }
}
