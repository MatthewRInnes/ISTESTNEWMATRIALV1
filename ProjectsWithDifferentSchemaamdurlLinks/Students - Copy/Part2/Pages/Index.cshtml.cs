// FILE TYPE: PageModel (.cs) for Index.cshtml. This is the server-side C# code-behind.
// It loads data from the database into properties that the Razor view (Index.cshtml) reads via Model.*.

// FRAMEWORK IMPORT: base type for Razor Page code-behind (OnGet, HTTP context, etc.).
using Microsoft.AspNetCore.Mvc.RazorPages;
// FRAMEWORK IMPORT: async LINQ extensions for EF Core queries (ToListAsync, FirstOrDefaultAsync, etc.).
using Microsoft.EntityFrameworkCore;
// PROJECT IMPORT: brings in your DbContext + entity class namespace (StudentsDbContext + Student).
using Students;

// NAMESPACE: MUST match the Razor view directive in Index.cshtml:
//   `@namespace Students.Pages`
namespace Students.Pages;

// CLASS: PageModel class. MUST match Index.cshtml directive:
//   `@model Students.Pages.IndexModel`
public class IndexModel : PageModel
{
    // FIELD TYPE: DbContext instance (database access). This is NOT the entity; it is the “database helper”.
    private readonly StudentsDbContext _db;

    // Constructor receives the registered DbContext from dependency injection.
    public IndexModel(StudentsDbContext db)
    {
        // Store the context for use in OnGetAsync.
        _db = db;
    }

    // PROPERTY TYPE: PageModel property.
    // Index.cshtml reads this via Model.Students, so the NAME must match the view usage.
    // ELEMENT TYPE: Student (entity class in LearningSite.cs). One Student = one row.
    public List<Student> Students { get; private set; } = [];

    // Runs automatically on HTTP GET for this page (when the user opens the site root URL).
    public async Task OnGetAsync()
    {
        // QUERY: load all rows from the Students table, ordered by FullName.
        Students = await _db.Students
            // Read-only query; no change tracking overhead for a simple list display.
            .AsNoTracking()
            // Sort alphabetically by FullName.
            // PROPERTY NAME: `x.FullName` is an ENTITY PROPERTY on Student.
            // MUST match LearningSite.cs:
            //   `public string FullName { get; set; }`
            // and that property maps to SQL via:
            //   `[Column(\"FullName\")]`
            .OrderBy(x => x.FullName)
            // Execute the query asynchronously and materialise a list.
            .ToListAsync();
    }
}
