-- 1. Create new database AdoNetDB

CREATE DATABASE AdoNetDB
GO

-- 2. Add table to the database named Author (ID, Firstname, Lastname...)

CREATE TABLE Author(
	Id INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(50) NULL,
	LastName NVARCHAR(50) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))
GO

-- 3. Add table to the database named Book (ID, Title, Genre, AuthorID)

CREATE TABLE Book(
	Id INT IDENTITY(1,1) NOT NULL,
	Title NVARCHAR(100) NULL,
	Genre NVARCHAR(50) NULL,
	AuthorID INT NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))
GO

-- Bonus: Create stored procedure for adding Authors and use it in your application to add new Authors

CREATE PROCEDURE AddAuthor(@FirstName NVARCHAR(50), @LastName NVARCHAR(50))
AS
BEGIN

INSERT INTO Author(FirstName, LastName)
VALUES (@FirstName, @LastName)

END
GO