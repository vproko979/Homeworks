--  Declare scalar variable for storing FirstName values
--  * Assign value ‘Antonio’ to the FirstName variable
--  * Find all Students having FirstName same as the variable

DECLARE @FirstName NVARCHAR(50)
SET @FirstName = 'Antonio'

SELECT *
FROM Student
WHERE FirstName = @FirstName

--  Declare table variable that will contain StudentId, StudentName and DateOfBirth
--  * Fill the table variable with all Female students

GO

DECLARE @FemaleStudents TABLE
(StudentId INT, StudentName NVARCHAR(50), DateOfBirth DATE);

INSERT INTO @FemaleStudents
SELECT ID, FirstName, DateOfBirth 
FROM Student
WHERE Gender = 'F'

SELECT *
FROM @FemaleStudents

GO

--  Declare temp table that will contain LastName and EnrolledDate columns
--  * Fill the temp table with all Male students having First Name starting with ‘A’
--  * Retrieve the students from the table which last name is with 7 characters

CREATE TABLE #MaleStudentsOnA
(LastName NVARCHAR(50), EnrollDate DATE)

INSERT INTO #MaleStudentsOnA
SELECT LastName, EnrolledDate
FROM Student
WHERE Gender = 'M' AND FirstName LIKE 'A%'

SELECT *
FROM #MaleStudentsOnA
WHERE LEN(LastName) = 7

DROP TABLE #MaleStudentsOnA

--  Find all teachers whose FirstName length is less than 5 and
--  * the first 3 characters of their FirstName and LastName are the same

SELECT FirstName, LastName
FROM Teacher
WHERE LEN(FirstName) < 5 AND
LEFT(FirstName, 3) = LEFT(LastName, 3)

--  Declare scalar function (fn_FormatStudentName) for retrieving the Student description for specific StudentId in the following format:
--  * StudentCardNumber without “sc-”
--  * “ – “
--  * First character of student FirstName
--  * “.”
--  * Student LastName

GO

CREATE FUNCTION dbo.fn_FormatStudentName(@StudentId INT)
RETURNS NVARCHAR(2000)
AS
BEGIN

DECLARE @Result NVARCHAR(2000)

SELECT @Result = SUBSTRING(StudentCardNumber, 4, 5) + ' - ' + LEFT(FirstName, 3) + '.' + LastName
FROM Student
WHERE ID = @StudentId

RETURN @Result
END

GO

SELECT *, dbo.fn_FormatStudentName(1) AS [Function outcome]
FROM Student
WHERE ID = 1

--  Create multi-statement table value function that for specific Teacher and Course will return list of students
--  (FirstName, LastName) who passed the exam, together with Grade and CreatedDate

GO

CREATE FUNCTION dbo.fn_StudentsWhoPassed (@TeacherID SMALLINT, @CourseID SMALLINT)
RETURNS @TableResult TABLE (FirstName NVARCHAR(50), LastName NVARCHAR(50), Grade TINYINT, CreateDate DATETIME)
AS 
BEGIN

INSERT INTO @TableResult
SELECT S.FirstName AS StudentFirstName, S.LastName AS StudentLastName, Grade, CreatedDate AS CreateDate
FROM Grade G
INNER JOIN Teacher T ON T.ID = G.TeacherID
INNER JOIN Student S ON S.ID = G.StudentID
INNER JOIN Course C ON C.ID = G.CourseID
WHERE T.ID = @TeacherID
AND C.ID = @CourseID
GROUP BY S.FirstName, S.LastName, Grade, CreatedDate
ORDER BY Grade

RETURN 
END

GO

DECLARE @TeacherID SMALLINT
SET @TeacherID = 7

DECLARE @CourseID SMALLINT
SET @CourseID = 7

SELECT * FROM dbo.fn_StudentsWhoPassed(@TeacherID, @CourseID)