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
  ('Example 1 (Careers)', 'https://www.uws.ac.uk/'),
  ('Example 2 (Careers)', 'https://moodle.uws.ac.uk/'),
  ('Example 3 (Careers)', 'https://www.uws.ac.uk/current-students/');
