DROP TABLE IF EXISTS MusicPlatforms;

CREATE TABLE MusicPlatforms (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Name TEXT NOT NULL,
  URL TEXT NOT NULL
);

INSERT INTO MusicPlatforms (Name, URL) VALUES
  ('Spotify', 'https://www.spotify.com'),
  ('Apple Music', 'https://music.apple.com'),
  ('SoundCloud', 'https://soundcloud.com'),
  ('Tidal', 'https://tidal.com'),
  ('Amazon Music', 'https://music.amazon.com');