-- This script creates the database table and sample rows. -- Run this to build the SQLite schema and seed data.
-- Table name MUST match: Channels -- Your C# model uses [Table("Channels")].
-- Column names MUST match: ID, Name, URL -- Your C# model uses [Column("ID")], [Column("Name")], [Column("URL")].

DROP TABLE IF EXISTS Channels; -- Delete the table if it already exists (lets you re-run the script).
CREATE TABLE Channels ( -- Create the table EF Core will query.
  ID INTEGER PRIMARY KEY AUTOINCREMENT, -- Primary key column (auto-incrementing).
  Name TEXT NOT NULL, -- Site name (must have a value).
  URL TEXT NOT NULL -- Site URL (must have a value).
); -- End CREATE TABLE.

INSERT INTO Channels (Name, URL) VALUES -- Insert sample rows.
  ('Example 1 (StudentServices)', 'https://www.uws.ac.uk/'), -- Row 1.
  ('Example 2 (StudentServices)', 'https://moodle.uws.ac.uk/'), -- Row 2.
  ('Example 3 (StudentServices)', 'https://www.uws.ac.uk/current-students/'); -- Row 3.
