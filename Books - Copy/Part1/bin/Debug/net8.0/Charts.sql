DROP TABLE IF EXISTS Charts;

CREATE TABLE Charts (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Name TEXT NOT NULL,
  URL TEXT NOT NULL
);

INSERT INTO Charts (Name, URL) VALUES
  ('Billboard Hot 100', 'https://www.billboard.com/charts/hot-100'),
  ('UK Top 40', 'https://www.officialcharts.com/charts/singles-chart'),
  ('Spotify Global Top 50', 'https://spotifycharts.com/regional/global/daily/latest'),
  ('Apple Music Top 100', 'https://music.apple.com/us/playlist/top-100-global/pl.d25f5d118fd28954f2cf2aceadd8aeb6'),
  ('YouTube Music Charts', 'https://charts.youtube.com/');