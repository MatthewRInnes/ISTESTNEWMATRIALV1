MusicPlatforms — LINQ ordering practice (TechForums layout: Part1 + Part2 per exercise)

Layout (same idea as C:\Users\matth\OneDrive\Desktop\TechForums)
----------------------------------------------------------------
Each exercise folder (OrderBy-01-… through OrderBy-12-…) contains:

  Part1\   — console app: results in the terminal
  Part2\   — ASP.NET Core Razor: results in the browser

Part 1 and Part 2 share the same small database (ID, Name, URL) and use the same LINQ ordering for that exercise.

How to run
----------
From an exercise folder, e.g. OrderBy-01-Name-A-Z-Alphabetical:

  Part 1:  cd Part1
           dotnet run --project Part1.csproj

  Part 2:  cd Part2
           dotnet run
           (open the http:// or https:// URL from the console; each exercise uses a different port in Part2\Properties\launchSettings.json, e.g. 5301/7301 for 01, 5302/7302 for 02, …)

Rebuild SQLite after editing MusicPlatforms.sql
------------------------------------------------
  sqlite3 MusicPlatforms.db ".read MusicPlatforms.sql"
Run that from the Part1 folder (or Part2; keep both copies in sync if you change the schema).

What changes between exercises
-----------------------------
Only the OrderBy / OrderByDescending / ThenBy chain (and the matching line in Part2\Pages\Index.cshtml.cs). See the table in the previous version of this file or the comment in each Part1\Program.cs.

Note: some folder names are historical (e.g. “ReleaseDate…”) but the data model is only three columns; see comments in Program.cs for what each sample sorts by today.

LINQ reference (Part 1 and Part 2 use the same chain)
-----------------------------------------------------
OrderBy-01   OrderBy(x => x.Name)
OrderBy-02   OrderByDescending(x => x.Name)
OrderBy-03   OrderBy(x => x.ID)
OrderBy-04   OrderByDescending(x => x.ID)
OrderBy-05   OrderBy(x => x.Url)
OrderBy-06   OrderByDescending(x => x.Url)
OrderBy-07   OrderBy(x => x.Name).ThenBy(x => x.Url)
OrderBy-08   OrderBy(x => x.Url).ThenBy(x => x.Name)
OrderBy-09   OrderByDescending(x => x.ID).ThenBy(x => x.Name)
OrderBy-10   OrderBy(x => x.Name.Length)
OrderBy-11   OrderByDescending(x => x.Name).ThenBy(x => x.Url)
OrderBy-12   OrderBy(x => x.Name.ToLower())
