DROP TABLE IF EXISTS Students;
CREATE TABLE Students (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  FullName TEXT NOT NULL,
  GPA REAL NOT NULL,
  PortfolioURL TEXT NOT NULL
);
INSERT INTO Students (FullName, GPA, PortfolioURL) VALUES
  ('Alice Johnson', 3.8, 'https://alice.dev/portfolio'),
  ('Bob Williams', 3.2, 'https://bob.design/work');