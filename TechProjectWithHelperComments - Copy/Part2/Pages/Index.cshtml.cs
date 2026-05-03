using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechForums; // must match TechForumsDbContext.cs — example: namespace TechForums;

namespace TechForums.Pages; // must match @namespace in Pages/Index.cshtml — example: @namespace TechForums.Pages

public class IndexModel : PageModel // must match @model TechForums.Pages.IndexModel in Index.cshtml
{
    private readonly TechForumsDbContext _db; // must match Program.cs AddDbContext<TechForumsDbContext>

    public IndexModel(TechForumsDbContext db) // DI type must match registration in Program.cs
    {
        _db = db;
    }

    public List<TechForum> TechForums { get; private set; } = []; // must match Model.TechForums in Index.cshtml — example: Model.TechForums.Count

    public async Task OnGetAsync()
    {
        TechForums = await _db.TechForums // must match DbSet property TechForums in TechForumsDbContext.cs
            .AsNoTracking()
            .OrderBy(x => x.Name) // must match public string Name on LearningSite in LearningSite.cs
            .ToListAsync();
    }
}
