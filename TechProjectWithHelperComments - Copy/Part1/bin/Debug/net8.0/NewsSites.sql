DROP TABLE IF EXISTS NewsSites;

CREATE TABLE NewsSites (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Name TEXT NOT NULL,
  URL TEXT NOT NULL
);

INSERT INTO NewsSites (Name, URL) VALUES
  ('BBC News', 'https://www.bbc.com/news'),
  ('CNN', 'https://www.cnn.com'),
  ('The Guardian', 'https://www.theguardian.com'),
  ('Reuters', 'https://www.reuters.com'),
  ('AP News', 'https://apnews.com');