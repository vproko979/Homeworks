CREATE TABLE AchievementType (
	ID SMALLINT IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(100) NULL,
	ParticipationRate TINYINT NOT NULL,
CONSTRAINT PK_AchievementType PRIMARY KEY CLUSTERED 
(
	ID ASC
))
GO