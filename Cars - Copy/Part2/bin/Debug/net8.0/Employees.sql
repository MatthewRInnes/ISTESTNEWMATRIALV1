DROP TABLE IF EXISTS Employees;
CREATE TABLE Employees (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  FirstName TEXT NOT NULL,
  LastName TEXT NOT NULL,
  LinkedInURL TEXT NOT NULL
);
INSERT INTO Employees (FirstName, LastName, LinkedInURL) VALUES
  ('John', 'Doe', 'https://linkedin.com/in/johndoe'),
  ('Jane', 'Smith', 'https://linkedin.com/in/janesmith');