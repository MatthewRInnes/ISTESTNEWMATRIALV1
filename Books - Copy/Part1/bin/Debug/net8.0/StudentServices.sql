-- Table MUST match C#: Channels (see `[Table("Channels")]` in `Channel.cs`).
-- Columns MUST match C#: ID, Name, URL (see `[Column("...")]` in `Channel.cs`).

DROP TABLE IF EXISTS Channels; -- Must match table name: Channels.
CREATE TABLE Channels ( -- Must match `[Table("Channels")]` in `Channel.cs`.
  ID INTEGER PRIMARY KEY AUTOINCREMENT, -- Must match `[Column("ID")]` in `Channel.cs`.
  Name TEXT NOT NULL, -- Must match `[Column("Name")]` in `Channel.cs`.
  URL TEXT NOT NULL -- Must match `[Column("URL")]` in `Channel.cs`.
);

INSERT INTO Channels (Name, URL) VALUES -- Must match table/columns above (Channels, Name, URL).
  ('Example 1 (StudentServices)', 'https://www.uws.ac.uk/'),
  ('Example 2 (StudentServices)', 'https://moodle.uws.ac.uk/'),
  ('Example 3 (StudentServices)', 'https://www.uws.ac.uk/current-students/');
