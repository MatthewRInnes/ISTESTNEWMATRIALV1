DROP TABLE IF EXISTS JobBoards;

CREATE TABLE JobBoards (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Name TEXT NOT NULL,
  URL TEXT NOT NULL
);

INSERT INTO JobBoards (Name, URL) VALUES
  ('Indeed', 'https://www.indeed.com'),
  ('LinkedIn Jobs', 'https://www.linkedin.com/jobs'),
  ('Monster', 'https://www.monster.com'),
  ('Glassdoor', 'https://www.glassdoor.com'),
  ('ZipRecruiter', 'https://www.ziprecruiter.com');