-- Minimal table matching your TechForums pattern: only ID, Name, URL.
DROP TABLE IF EXISTS MusicPlatforms;

CREATE TABLE MusicPlatforms (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Name TEXT NOT NULL,
  URL TEXT NOT NULL
);

INSERT INTO MusicPlatforms (Name, URL) VALUES
  ('Amazon Music', 'https://music.amazon.co.uk'),
  ('Apple Music', 'https://music.apple.com'),
  ('Bandcamp', 'https://bandcamp.com'),
  ('Deezer', 'https://www.deezer.com'),
  ('Qobuz', 'https://www.qobuz.com'),
  ('SoundCloud', 'https://soundcloud.com'),
  ('Spotify', 'https://www.spotify.com'),
  ('Tidal', 'https://tidal.com'),
  ('YouTube Music', 'https://music.youtube.com');
