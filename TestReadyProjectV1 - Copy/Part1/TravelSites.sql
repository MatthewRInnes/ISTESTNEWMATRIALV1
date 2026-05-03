-- Remove any previous version of this table so the script can be re-run cleanly.
DROP TABLE IF EXISTS TravelSites;

-- Define one table to hold travel-site rows (name + URL pairs).
CREATE TABLE TravelSites (
  -- Surrogate primary key; SQLite fills this automatically for each new row.
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  -- Human-readable site name (shown in UIs and searches).
  TravelName TEXT NOT NULL,
  -- Full URL including scheme (https://…).
  TravelURL TEXT NOT NULL
);

-- Seed rows so the table is non-empty after creation.
INSERT INTO TravelSites (TravelName, TravelURL) VALUES
  ('Expedia', 'https://www.expedia.com'),
  ('Booking.com', 'https://www.booking.com'),
  ('Airbnb', 'https://www.airbnb.com'),
  ('Kayak', 'https://www.kayak.com'),
  ('TripAdvisor', 'https://www.tripadvisor.com');
