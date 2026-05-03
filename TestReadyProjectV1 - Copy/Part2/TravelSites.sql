-- Drops the table if it already exists (allows repeating this script without errors).
DROP TABLE IF EXISTS TravelSites;

-- Table storing travel booking / comparison sites used by the TravelSites practice project.
CREATE TABLE TravelSites (
  -- Auto-increment integer primary key.
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  -- Site title as shown to users (not null).
  TravelName TEXT NOT NULL,
  -- Link users follow (not null).
  TravelURL TEXT NOT NULL
);

-- Example data matching typical travel platforms (five rows).
INSERT INTO TravelSites (TravelName, TravelURL) VALUES
  ('Expedia', 'https://www.expedia.com'),
  ('Booking.com', 'https://www.booking.com'),
  ('Airbnb', 'https://www.airbnb.com'),
  ('Kayak', 'https://www.kayak.com'),
  ('TripAdvisor', 'https://www.tripadvisor.com');
