TestRedoneWithoutLinks — Part 1 + Part 2 (streaming channel names only, no URL links)

Layout (same idea as TechForums-style coursework):

  Part1\   Console app — prints channel names in the terminal (plain text, no hyperlinks).
  Part2\   Razor web app — lists the same names in the browser (list items are text only, not <a> links).

Both parts use the same Channel model (ID + Name), SQLite file name StreamingSites.db, and the same seed data.
Each project builds its own database under its bin folder unless you point both connection strings at a shared path.

Run Part 1:
  cd Part1
  dotnet run --project Part1.csproj

Run Part 2:
  cd Part2
  dotnet run --project Part2.csproj
