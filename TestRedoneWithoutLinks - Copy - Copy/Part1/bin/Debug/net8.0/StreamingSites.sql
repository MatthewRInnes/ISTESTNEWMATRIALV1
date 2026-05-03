-- Optional reference script: matches the Channels entity (names only — no URL columns).
-- Drop existing table so the script can be re-run cleanly during development.
DROP TABLE IF EXISTS Channels;

-- Table backing my Channel entity; column names must match [Column(...)] attributes.
CREATE TABLE Channels (
    -- Surrogate primary key; SQLite fills this when inserting new rows.
    ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    -- Display name for each streaming site row.
    Name TEXT NOT NULL
);

-- Seed IDs explicit here; EF seed in Program.cs may omit IDs and rely on auto-increment.
INSERT INTO Channels (ID, Name) VALUES (1, 'Netflix');
INSERT INTO Channels (ID, Name) VALUES (2, 'YouTube');
INSERT INTO Channels (ID, Name) VALUES (3, 'Disney+');
INSERT INTO Channels (ID, Name) VALUES (4, 'Discovery+');
INSERT INTO Channels (ID, Name) VALUES (5, 'Apple TV');
