--Create new view (vv_StudentGrades) that will List all StudentIds and count of Grades per student

GO

CREATE VIEW vv_StudentGrades
AS
SELECT StudentID, COUNT(Grade) AS [Count of grades]
FROM Grade
GROUP BY StudentID

GO

SELECT * 
FROM vv_StudentGrades

--Change the view to show Student First and Last Names instead of StudentID

GO

ALTER VIEW vv_StudentGrades
AS
SELECT StudentID, S.FirstName AS Name, S.LastName AS Surname, COUNT(G.Grade) AS [Count of grades]
FROM Grade G
INNER JOIN Student S
ON S.ID = G.StudentID
GROUP BY StudentID, S.FirstName, S.LastName

GO

SELECT * 
FROM vv_StudentGrades

--List all rows from view ordered by biggest Grade Count

SELECT * 
FROM vv_StudentGrades
ORDER BY [Count of grades] DESC

--Create new view (vv_StudentGradeDetails) that will List all Students (FirstName and LastName)
--and Count the courses he passed through the exam(Ispit)

GO

CREATE VIEW vv_StudentGradeDetails
AS
SELECT StudentID, S.FirstName AS Name, S.LastName AS Surname, COUNT(Grade) AS [Count]
FROM Grade G
INNER JOIN Student S ON S.ID = G.StudentID
INNER JOIN GradeDetails GD ON GD.GradeID = G.ID
RIGHT JOIN AchievementType AT ON AT.ID = GD.AchievementTypeID
WHERE AT.Name = 'Ispit'
GROUP BY StudentID, S.LastName, S.FirstName

GO

SELECT *
FROM vv_StudentGradeDetails