DROP TABLE IF EXISTS Cars;
CREATE TABLE Cars (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Brand TEXT NOT NULL,
  Model TEXT NOT NULL,
  CarsURL TEXT NOT NULL
);
INSERT INTO Cars (Brand, Model, CarsURL) VALUES
  ('Toyota', 'Camry', 'https://cars.com/toyota/camry'),
  ('Honda', 'Civic', 'https://cars.com/honda/civic');