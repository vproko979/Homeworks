using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Dapper
{
    class Program
    {
        private static string _connectionString = @"Server=DESKTOP-L1IKI7N\SQLEXPRESS;Database=AdoNetDB;Trusted_Connection=True;";
        static void Main(string[] args)
        {

            Console.WriteLine("Choose option(using the numbers in front of the option):");
            Console.WriteLine();
            Console.WriteLine("1) Add book");
            Console.WriteLine("2) Edit book");
            Console.WriteLine("3) Add author");
            Console.WriteLine("4) Edit author");
            Console.WriteLine("5) Get all authors");
            Console.WriteLine();
            Console.Write("User's selection: ");
            var usersChoice = Console.ReadLine();

            if (usersChoice == "1")
            {
                Console.Clear();
                AddBook();
            }

            if (usersChoice == "2")
            {
                Console.Clear();
                EditBook();
            }

            if (usersChoice == "3")
            {
                Console.Clear();
                AddAuthor();
            }

            if (usersChoice == "4")
            {
                Console.Clear();
                EditAuthor();
            }

            if (usersChoice == "5")
            {
                Console.Clear();
                GetAllAuthors();
            }

            Console.ReadLine();

        }

        private static void AddBook()
        {
            Console.Write("Title: ");
            var bookTitle = Console.ReadLine();
            Console.Write("Genre: ");
            var bookGenre = Console.ReadLine();
            Console.Write("Author's ID: ");
            var authorsId = Console.ReadLine();

            string sql = $"INSERT INTO Book (Title, Genre, AuthorID) VALUES('{bookTitle}', '{bookGenre}', '{authorsId}');";

            using (var connection = new SqlConnection(_connectionString))
            {

                var book = connection.Query(sql);

                Console.WriteLine("Book successfully added");
            }
        }

        private static void EditBook()
        {
            Console.Write("Enter author's id: ");
            var authorsId = Console.ReadLine();
            Console.Write("Title: ");
            var bookTitle = Console.ReadLine();
            Console.Write("Genre: ");
            var bookGenre = Console.ReadLine();

            string sql = $"UPDATE Book SET Title = '{bookTitle}', Genre = '{bookGenre}' WHERE AuthorID = {authorsId};";

            using (var connection = new SqlConnection(_connectionString))
            {

                var book = connection.Query(sql);

                Console.WriteLine("The book successfully updated");

            }
        }

        private static void AddAuthor()
        {
            Console.Write("Fist Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();

            using (var connection = new SqlConnection(_connectionString))
            {

                var affectedRows = connection.Execute("AddAuthor", new { FirstName = firstName, LastName = lastName }, commandType: CommandType.StoredProcedure);

                Console.WriteLine($"Inserted {affectedRows} item");

            }
        }

        private static void EditAuthor()
        {
            Console.Write("Enter author's name: ");
            var authorsName = Console.ReadLine();
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();

            string sql = $"UPDATE Author SET FirstName = '{firstName}', LastName = '{lastName}' WHERE FirstName LIKE '%{authorsName}%';";

            using (var connection = new SqlConnection(_connectionString))
            {

                var author = connection.Query(sql);

                Console.WriteLine("The author's info has been updated successfully");
            }
        }

        private static void GetAllAuthors()
        {
            string sql = "SELECT * FROM Book AS B INNER JOIN Author AS A ON A.Id = B.AuthorID;";

            using (var connection = new SqlConnection(_connectionString))
            {

                var books = connection.Query<Book, Author, Book>(sql,
                    (book, author) =>
                    {
                        book.Author = author;
                        return book;
                    },
                    splitOn: "AuthorId")
                    .Distinct().ToList();

                foreach (var item in books)
                {
                    Console.WriteLine($"{item.Author.FirstName} {item.Author.LastName} wrote \"{item.Title}\"");
                }

            }
        }
    }
}
