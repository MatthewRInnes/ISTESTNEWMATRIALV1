-- Same schema as Part 1; must match [Table("LearningSites")] in LearningSite.cs.

DROP TABLE IF EXISTS LearningSites;

CREATE TABLE LearningSites (
  ID INTEGER PRIMARY KEY AUTOINCREMENT,
  Name TEXT NOT NULL,
  URL TEXT NOT NULL
);

INSERT INTO LearningSites (Name, URL) VALUES
  ('Canvas', 'https://www.instructure.com/canvas'),
  ('Moodle', 'https://moodle.org'),
  ('Blackboard Learn', 'https://www.anthology.com/products/teaching-and-learning/blackboard-learn'),
  ('Microsoft Teams for Education', 'https://www.microsoft.com/education/products/teams'),
  ('Google Classroom', 'https://classroom.google.com');
