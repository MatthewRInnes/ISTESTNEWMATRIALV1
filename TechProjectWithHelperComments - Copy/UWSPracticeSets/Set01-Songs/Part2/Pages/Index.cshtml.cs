using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Set01.Songs.Part2.Pages;

// This class loads the list of items from the database for the page to show.
public class IndexModel : PageModel
{
    private readonly AppDbContext _db;

    public IndexModel(AppDbContext db)
    {
        _db = db;
    }

    // This list is what the page loops over.
    public List<Item> Items { get; private set; } = [];

    public async Task OnGetAsync()
    {
        // This reads every row from the table `Channels` (because the model is mapped to that table).
        Items = await _db.Items
            .AsNoTracking()
            .OrderBy(i => i.Text)
            .ToListAsync();
    }
}
