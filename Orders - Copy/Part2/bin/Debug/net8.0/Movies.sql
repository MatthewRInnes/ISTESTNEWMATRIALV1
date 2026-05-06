DROP TABLE IF EXISTS Movies;
CREATE TABLE Movies (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  MovieName TEXT NOT NULL,
  Rating REAL NOT NULL,
  IMDbURL TEXT NOT NULL
);
INSERT INTO Movies (MovieName, Rating, IMDbURL) VALUES
  ('Inception', 8.8, 'https://imdb.com/title/inception'),
  ('The Matrix', 8.7, 'https://imdb.com/title/matrix');