DROP TABLE IF EXISTS Books;
CREATE TABLE Books (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Title TEXT NOT NULL,
  Author TEXT NOT NULL,
  AmazonURL TEXT NOT NULL
);
INSERT INTO Books (Title, Author, AmazonURL) VALUES
  ('1984', 'George Orwell', 'https://amazon.com/1984'),
  ('Dune', 'Frank Herbert', 'https://amazon.com/dune');