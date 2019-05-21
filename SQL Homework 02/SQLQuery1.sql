-- Find all Students with FirstName = Antonio

SELECT *
FROM Student
WHERE FirstName = 'Antonio'

-- Find all Students with DateOfBirth greater than ‘1999-01-01’

SELECT *
FROM Student
WHERE DateOfBirth > '1999-01-01'

-- Find all Male students

SELECT *
FROM Student
WHERE Gender = 'M'

-- Find all Students with LastName starting With ‘T’

SELECT *
FROM Student
WHERE LastName LIKE 'T%'

-- Find all Students Enrolled in January/1998

SELECT *
FROM Student
WHERE EnrolledDate LIKE '1998-01%'

-- Find all Students with LastName starting With ‘J’ enrolled in January/1998

SELECT *
FROM Student
WHERE LastName LIKE 'J%' AND EnrolledDate LIKE '1998-01%'

-- Find all Students with FirstName = Antonio ordered by Last Name

SELECT *
FROM Student
WHERE FirstName = 'Antonio'
ORDER BY LastName ASC

-- List all Students ordered by FirstName

SELECT *
FROM Student
ORDER BY FirstName ASC

-- Find all Male students ordered by EnrolledDate, starting from the last enrolled

SELECT *
FROM Student
ORDER BY EnrolledDate DESC

-- List all Teacher First Names and Student First Names in single result set with duplicates

SELECT FirstName
FROM Teacher
UNION ALL
SELECT FirstName
FROM Student

-- List all Teacher Last Names and Student Last Names in single result set. Remove duplicates

SELECT LastName
FROM Teacher
UNION
SELECT LastName
FROM Student

-- List all common First Names for Teachers and Students

SELECT FirstName
FROM Teacher
INTERSECT
SELECT FirstName
FROM Student

-- Change GradeDetails table always to insert value 100 in AchievementMaxPoints column if no value is provided on insert

ALTER TABLE GradeDetails
ADD CONSTRAINT DF_GradeDetails_AchievementMaxPoints
DEFAULT 100 FOR AchievementMaxPoints

-- Change GradeDetails table to prevent inserting AchievementPoints that will more than AchievementMaxPoints

ALTER TABLE GradeDetails
ADD CONSTRAINT CHK_GradeDetails_AchievementPoints
CHECK (AchievementPoints<=100)

-- Change AchievementType table to guarantee unique names across the Achievement types

ALTER TABLE AchievementType WITH CHECK
ADD CONSTRAINT AchievementType_UC_Name UNIQUE (Name)

-- Create Foreign key constraints from diagram or with script

ALTER TABLE [dbo].[Grade]  WITH CHECK
ADD  CONSTRAINT [FK_Grade_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])

ALTER TABLE [dbo].[Grade]  WITH CHECK
ADD  CONSTRAINT [FK_Grade_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])

ALTER TABLE [dbo].[Grade]  WITH CHECK
ADD  CONSTRAINT [FK_Grade_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])

ALTER TABLE [dbo].[GradeDetails]  WITH CHECK
ADD  CONSTRAINT [FK_GradeDetails_AchievementType] FOREIGN KEY([AchievementTypeID])
REFERENCES [dbo].[AchievementType] ([ID])

ALTER TABLE [dbo].[GradeDetails]  WITH CHECK
ADD  CONSTRAINT [FK_GradeDetails_Grade] FOREIGN KEY([GradeID])
REFERENCES [dbo].[Grade] ([ID])

--List all possible combinations of Courses names and AchievementType names that can be passed by student

SELECT c.Name AS [Course name], AT.Name AS [Achievement type name]
FROM Course c
CROSS JOIN AchievementType AT


--List all Teachers that has any exam Grade

SELECT DISTINCT T.FirstName, T.LastName
FROM Teacher T
INNER JOIN Grade G 
ON G.TeacherID = T.ID

--List all Teachers without exam Grade

SELECT DISTINCT T.FirstName, T.LastName
FROM Teacher T
LEFT JOIN Grade G 
ON T.ID = G.TeacherID
WHERE G.TeacherID IS NULL

--List all Students without exam Grade (using Right Join)

SELECT S.FirstName, S.LastName
FROM Grade G
RIGHT JOIN Student S
ON G.StudentID = S.ID
WHERE G.StudentID IS NULL