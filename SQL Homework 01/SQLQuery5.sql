CREATE TABLE Grade (
	ID INT IDENTITY(1,1) NOT NULL,
	StudentID INT NOT NULL,
	CourseID SMALLINT NOT NULL,
	TeacherID SMALLINT NOT NULL,
	Grade TINYINT NOT NULL,
	Comment NVARCHAR(100) NULL,
	CreatedDate DATE NOT NULL,
CONSTRAINT PK_Grade PRIMARY KEY CLUSTERED 
(
	ID ASC
))
GO