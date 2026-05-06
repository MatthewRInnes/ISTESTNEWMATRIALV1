DROP TABLE IF EXISTS TechForums;

CREATE TABLE TechForums (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Name TEXT NOT NULL,
  URL TEXT NOT NULL
);

INSERT INTO TechForums (Name, URL) VALUES
  ('Stack Overflow', 'https://stackoverflow.com'),
  ('Reddit', 'https://www.reddit.com'),
  ('GitHub Discussions', 'https://github.com/discussions'),
  ('Dev.to', 'https://dev.to'),
  ('Hacker News', 'https://news.ycombinator.com');