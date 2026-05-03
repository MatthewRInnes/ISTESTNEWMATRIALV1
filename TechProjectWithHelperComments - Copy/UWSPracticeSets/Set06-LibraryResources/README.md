## Set06 — LibraryResources

This set is made to look like the class test structure:

- **Part1**: Console app (prints results in the terminal)
- **Part2**: Browser app (shows clickable links)

### Names that must match (this is the main thing you practise)

- **Database file name**: `LibraryResources.db` (code must look for the same name)
- **SQL script name**: `LibraryResources.sql` (used to create the database if it’s missing)
- **Table name**: `Channels` (must match `[Table("...")]` and the SQL)
- **Text column**: `Name` (must match `[Column("...")]`)
- **Link column**: `URL` (must match `[Column("...")]`)

### How to run

1. Open a terminal in `Part1`, run `dotnet run`, type a name exactly like one of the example rows.
2. Open a terminal in `Part2`, run `dotnet run`, and the browser page will list clickable links.
