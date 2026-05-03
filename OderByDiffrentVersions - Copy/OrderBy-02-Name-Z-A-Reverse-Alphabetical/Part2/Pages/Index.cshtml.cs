using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicPlatforms;

namespace MusicPlatforms.Pages;

// Browser host page — use the same LINQ ordering as Part 1 in this folder.
public class IndexModel : PageModel
{
    private readonly MusicPlatformsDbContext _db;

    public IndexModel(MusicPlatformsDbContext db)
    {
        _db = db;
    }

    public List<MusicPlatform> Platforms { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Platforms = await _db.MusicPlatforms
            .AsNoTracking()
            .OrderByDescending(x => x.Name)
            .ToListAsync();
    }
}
