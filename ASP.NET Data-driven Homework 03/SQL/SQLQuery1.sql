--CREATE DATABASE AdoNetDB

--GO

--CREATE TABLE Author(
--	Id INT IDENTITY(1,1) NOT NULL,
--	FirstName NVARCHAR(50) NULL,
--	LastName NVARCHAR(50) NULL,
-- CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
--(
--	[Id] ASC
--))

--GO

--CREATE TABLE Book(
--	Id INT IDENTITY(1,1) NOT NULL,
--	Title NVARCHAR(100) NULL,
--	Genre NVARCHAR(50) NULL,
--	AuthorID INT NOT NULL,
-- CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
--(
--	[Id] ASC
--))

--GO

--ALTER TABLE Book
--ADD FOREIGN KEY (AuthorID) REFERENCES Author(Id);

--GO

--CREATE PROCEDURE AddAuthor(@FirstName NVARCHAR(50), @LastName NVARCHAR(50))
--AS
--BEGIN

--INSERT INTO Author(FirstName, LastName)
--VALUES (@FirstName, @LastName)

--END
--GO

--INSERT INTO Author (FirstName, LastName)
--VALUES('Jules', 'Verne');

--INSERT INTO Book (Title, Genre, AuthorID) 
--VALUES('Twenty Thousand Leagues Under the Sea', 'Science fiction', 1);

--INSERT INTO Author (FirstName, LastName)
--VALUES('Miguel', 'de Cervantes');

--INSERT INTO Book (Title, Genre, AuthorID) 
--VALUES('Don Quixote', 'Novel', 2);

--INSERT INTO Author (FirstName, LastName)
--VALUES('Herman', 'Melville');

--INSERT INTO Book (Title, Genre, AuthorID) 
--VALUES('Moby Dick', 'Novel', 3);

--INSERT INTO Author (FirstName, LastName)
--VALUES('William', 'Shakespeare');

--INSERT INTO Book (Title, Genre, AuthorID) 
--VALUES('Hamlet', 'Drama', 4);

--INSERT INTO Author (FirstName, LastName)
--VALUES('Joseph', 'Heller');

--INSERT INTO Book (Title, Genre, AuthorID) 
--VALUES('Catch-22', 'Novel', 5);



--SELECT *
--FROM Book

--SELECT *
--FROM Author