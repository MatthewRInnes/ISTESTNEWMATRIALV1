DROP TABLE IF EXISTS Orders;
CREATE TABLE Orders (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  CustomerName TEXT NOT NULL,
  TotalAmount REAL NOT NULL,
  OrdersURL TEXT NOT NULL
);
INSERT INTO Orders (CustomerName, TotalAmount, OrdersURL) VALUES
  ('Mike Ross', 150.50, 'https://Orderss.com/order123'),
  ('Rachel Zane', 89.99, 'https://Orderss.com/order456');