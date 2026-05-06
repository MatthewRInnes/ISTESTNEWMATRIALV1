-- This script creates the database table and sample rows.
-- Table name MUST match: Channels
-- Column names MUST match: ID, Name, URL

DROP TABLE IF EXISTS Channels;
CREATE TABLE Channels (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Name TEXT NOT NULL,
  URL TEXT NOT NULL
);

INSERT INTO Channels (Name, URL) VALUES
  ('Example 1 (Cafes)', 'https://www.uws.ac.uk/'),
  ('Example 2 (Cafes)', 'https://moodle.uws.ac.uk/'),
  ('Example 3 (Cafes)', 'https://www.uws.ac.uk/current-students/');
