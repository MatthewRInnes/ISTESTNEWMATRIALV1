DROP TABLE IF EXISTS Products;
CREATE TABLE Products (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  ProductName TEXT NOT NULL,
  Price REAL NOT NULL,
  ProductURL TEXT NOT NULL
);
INSERT INTO Products (ProductName, Price, ProductURL) VALUES
  ('Laptop', 999.99, 'https://www.amazon.com/laptop'),
  ('Mouse', 19.99, 'https://www.bestbuy.com/mouse'),
  ('Keyboard', 49.99, 'https://www.newegg.com/keyboard');