using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BookLibrary
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
            

            Console.ReadLine();
        }

        private static void TestConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();
            Console.WriteLine("Connection open.");

            connection.Close();
            Console.WriteLine("Connection closed.");
        }

        private static void AddBook()
        {
            Console.Write("Title: ");
            var bookTitle = Console.ReadLine();
            Console.Write("Genre: ");
            var bookGenre = Console.ReadLine();
            Console.Write("Author's ID: ");
            var authorsId = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"INSERT INTO Book (Title, Genre, AuthorID) VALUES('{bookTitle}', '{bookGenre}', '{authorsId}');";

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("Book added successfully");
        }

        private static void EditBook()
        {
            Console.Write("Enter author's id: ");
            var authorsId = Console.ReadLine();
            Console.Write("Title: ");
            var bookTitle = Console.ReadLine();
            Console.Write("Genre: ");
            var bookGenre = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"UPDATE Book SET Title = '{bookTitle}', Genre = '{bookGenre}' WHERE AuthorID = {authorsId};";

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("Book successfully updated.");
        }

        private static void AddAuthor()
        {
            Console.Write("Fist Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand("AddAuthor", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("Author successfully Added");
        }

        private static void EditAuthor()
        {
            Console.Write("Enter author's name: ");
            var authorsName = Console.ReadLine();
            Console.Write("First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            var lastName = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"UPDATE Author SET FirstName = '{firstName}', LastName = '{lastName}' WHERE FirstName LIKE '%{authorsName}%';";

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine("Author successfully updated.");
        }
    }
}
