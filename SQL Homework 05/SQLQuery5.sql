--  Create new procedure called CreateGrade
--  Procedure should create only Grade header info (not Grade Details) 
--  Procedure should return the total number of grades in the system for the Student on input (from the CreateGrade)
--  Procedure should return second resultset with the MAX Grade of all grades for the Student and Teacher on input (regardless the Course)

GO

CREATE PROCEDURE dbo.CreateGrade(@StudentID INT, @CourseID SMALLINT, @TeacherID SMALLINT, @Grade TINYINT, @CreatedDate DATETIME)
AS
BEGIN

INSERT INTO dbo.Grade (StudentID, CourseID, TeacherID, Grade, CreatedDate)
VALUES (@StudentID, @CourseID, @TeacherID, @Grade, @CreatedDate)

SELECT COUNT(*) AS TotalGradesForTheStudent
FROM dbo.Grade
WHERE StudentID = @StudentID

SELECT MAX(Grade) AS MaxGradeForTheStudent
FROM dbo.Grade
WHERE StudentID = @StudentID
AND TeacherID = @TeacherID

END
GO

EXECUTE dbo.CreateGrade 
@StudentID = 7, 
@CourseID = 7, 
@TeacherID = 79, 
@Grade = 10, 
@CreatedDate = '1999-07-06 00:00:00.000'

-- Proverka
SELECT TOP 1 *
FROM dbo.Grade
ORDER BY 1 DESC


--  Create new procedure called CreateGradeDetail
--  Procedure should add details for specific Grade (new record for new AchievementTypeID, Points, MaxPoints, Date for specific Grade)
--  Output from this procedure should be resultset with SUM of GradePoints calculated with formula AchievementPoints/AchievementMaxPoints*ParticipationRate for specific Grade

GO

CREATE OR ALTER PROCEDURE dbo.CreateGradeDetail(@GradeID INT, @AchievementTypeID TINYINT, @AchievementPoints TINYINT, @AchievementMaxPoints TINYINT, @AchievementDate DATETIME)
AS
BEGIN

BEGIN TRY
	INSERT INTO dbo.GradeDetails(GradeID, AchievementTypeID, AchievementPoints, AchievementMaxPoints, AchievementDate)
	VALUES (@GradeID, @AchievementTypeID, @AchievementPoints, @AchievementMaxPoints, @AchievementDate)

	SELECT SUM(CAST(GD.AchievementPoints AS DECIMAL(5,2)) / CAST(GD.AchievementMaxPoints AS DECIMAL(5,2)) * ACT.ParticipationRate) AS GradePoints
	FROM GradeDetails AS GD
	INNER JOIN AchievementType AS ACT ON GD.AchievementTypeID = ACT.ID
	WHERE GD.GradeID = @GradeID
END TRY
BEGIN CATCH
SELECT  
    ERROR_NUMBER() AS ErrorNumber  
    ,ERROR_SEVERITY() AS ErrorSeverity  
    ,ERROR_STATE() AS ErrorState  
    ,ERROR_PROCEDURE() AS ErrorProcedure  
    ,ERROR_LINE() AS ErrorLine  
    ,ERROR_MESSAGE() AS ErrorMessage;
END CATCH;

END
GO

EXECUTE dbo.CreateGradeDetail
@GradeID = 16030, 
@AchievementTypeID = 5, 
@AchievementPoints = 79, 
@AchievementMaxPoints = 100, 
@AchievementDate = '2002-02-24 00:00:00.000'

-- Proverka
SELECT TOP 1 *
FROM dbo.GradeDetails
ORDER BY 1 DESC

--  Add error handling on CreateGradeDetail procedure
--  Test the error handling by inserting not-existing values for AchievementTypeID

EXECUTE dbo.CreateGradeDetail
@GradeID = 20122, 
@AchievementTypeID = 15, 
@AchievementPoints = 79, 
@AchievementMaxPoints = 100, 
@AchievementDate = '2002-02-24 00:00:00.000'