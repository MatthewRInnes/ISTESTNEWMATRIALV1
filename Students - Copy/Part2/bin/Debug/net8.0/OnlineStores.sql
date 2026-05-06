DROP TABLE IF EXISTS OnlineStores;

CREATE TABLE OnlineStores (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Name TEXT NOT NULL,
  URL TEXT NOT NULL
);

INSERT INTO OnlineStores (Name, URL) VALUES
  ('eBay', 'https://www.ebay.com'),
  ('Etsy', 'https://www.etsy.com'),
  ('Walmart', 'https://www.walmart.com'),
  ('Target', 'https://www.target.com'),
  ('Best Buy', 'https://www.bestbuy.com');