-- Same setup as Part 1: one table called Channels with the sample streaming sites inside.
DROP TABLE IF EXISTS Channels;

CREATE TABLE Channels (
    ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
    Name TEXT NOT NULL,
    URL TEXT NOT NULL
);

INSERT INTO Channels (ID, Name, URL) VALUES (1, 'Netflix', 'https://www.netflix.com');
INSERT INTO Channels (ID, Name, URL) VALUES (2, 'YouTube', 'https://www.youtube.com/');
INSERT INTO Channels (ID, Name, URL) VALUES (3, 'Disney+', 'https://www.disneyplus.com');
INSERT INTO Channels (ID, Name, URL) VALUES (4, 'Discovery+', 'https://www.discoveryplus.com/');
INSERT INTO Channels (ID, Name, URL) VALUES (5, 'Apple TV', 'https://tv.apple.com/');
