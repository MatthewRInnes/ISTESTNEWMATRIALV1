## Part 2 (Razor Pages + SQLite + EF Core) — little “gotchas” explained

This folder is your **web version** of the same database idea from Part 1.

### Razor rule that caused that error earlier

Razor “directives” like these:

- `@page`
- `@model`
- `@namespace`
- `@using`
- `@addTagHelper`

must be **on their own line**.

If you do “side-of-line” comments like this, Razor can break:

```cshtml
@page @* ❌ Razor reads extra text and throws errors *@
@model StreamingSites.Pages.IndexModel @* ❌ same problem *@
```

Do this instead (comment on the line above):

```cshtml
@* ✅ `@page` makes this file respond to a URL *@
@page

@* ✅ `@model` tells Razor which PageModel backs the page *@
@model StreamingSites.Pages.IndexModel
```

### Quick “where is what?” map

- `Program.cs`: boots the website and wires up EF Core + Razor Pages
- `StreamingSitesDbContext.cs`: the EF Core database gateway (the “Channels table in code”)
- `Pages/Index.cshtml.cs`: the page logic (loads the list from the DB)
- `Pages/Index.cshtml`: the page UI (loops over `Model.Channels` and prints links)
- `Channel.cs`: one row from the `Channels` table (ID, Name, Url)

