using BookLibrary.Data;
using BookLibrary.Data.Interfaces;
using BookLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.App
{
    class Program
    {

        IBookRepository _bookRepository = new BookRepository();
        IAuthorRepository _authorRepository = new AuthorRepository();
        static void Main(string[] args)
        {
            Program current = new Program();

            Console.WriteLine("Menu:");
            Console.WriteLine();
            Console.WriteLine("1) Full list");
            Console.WriteLine("2) Books list");
            Console.WriteLine("3) Authors list");
            Console.WriteLine("4) Get book by ID");
            Console.WriteLine("5) Get author by ID");
            Console.WriteLine("6) Add new title");
            Console.WriteLine("7) Edit book");
            Console.WriteLine("8) Edit author");
            Console.WriteLine("9) Delete book");
            Console.WriteLine("10) Delete author");
            Console.WriteLine();
            Console.Write("Selected: ");
            var userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    current.GetFullList();
                    break;
                case "2":
                    Console.Clear();
                    current.GetAllBooks();
                    break;
                case "3":
                    Console.Clear();
                    current.GetAllAuthors();
                    break;
                case "4":
                    Console.Clear();
                    current.GetBookById();
                    break;
                case "5":
                    Console.Clear();
                    current.GetAuthorById();
                    break;
                case "6":
                    Console.Clear();
                    current.AddNewTitle();
                    break;
                case "7":
                    Console.Clear();
                    current.EditBook();
                    break;
                case "8":
                    Console.Clear();
                    current.EditAuthor();
                    break;
                case "9":
                    Console.Clear();
                    current.DeleteBook();
                    break;
                case "10":
                    Console.Clear();
                    current.DeleteAuthor();
                    break;
            }

            Console.ReadLine();
        }

        private void GetFullList()
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                var list = context.Authors.Include(a => a.Books).ToList();

                foreach (var author in list)
                {
                    foreach (var book in author.Books)
                    {
                        Console.WriteLine($"The author {author.FirstName} {author.LastName} wrote the book \"{book.Title}\"");
                    }
                }
            }
        }

        private void DeleteAuthor()
        {
            Console.Write("Enter the id of the author you want to delete: ");
            var authorId = int.Parse(Console.ReadLine());

            _authorRepository.DeleteAuthor(authorId);

            Console.WriteLine("The author has been successfully deleted");
        }

        private void DeleteBook()
        {
            Console.Write("Enter the id of the book you want to delete: ");
            var bookId = int.Parse(Console.ReadLine());

            _bookRepository.DeleteBook(bookId);

            Console.WriteLine("The book has been successfully removed");
        }

        private void EditAuthor()
        {
            Console.Write("Enter author's id: ");
            var authorId = int.Parse(Console.ReadLine());
            Console.Write("Enter author's name: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter author's last name: ");
            var lastName = Console.ReadLine();

            Author newAuthor = new Author();
            newAuthor.Id = authorId;
            newAuthor.FirstName = firstName;
            newAuthor.LastName = lastName;

            _authorRepository.EditAuthor(newAuthor);

            Console.WriteLine("Author successfully edited");
        }

        private void EditBook()
        {
            Console.Write("Enter book's ID: ");
            var bookId = int.Parse(Console.ReadLine());
            Console.Write("Enter book's title: ");
            var title = Console.ReadLine();
            Console.Write("Enter book's genre: ");
            var genre = Console.ReadLine();
            Console.Write("Enter author's ID: ");
            var authorId = int.Parse(Console.ReadLine());

            Book newBook = new Book();
            newBook.Id = bookId;
            newBook.Title = title;
            newBook.Genre = genre;
            newBook.AuthorID = authorId;

            _bookRepository.EditBook(newBook);

            Console.WriteLine("Book successfully edited.");
        }

        private void AddNewTitle()
        {
            Console.Write("Enter author's name: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter author's last name: ");
            var lastName = Console.ReadLine();

            Author newAuthor = new Author();
            newAuthor.FirstName = firstName;
            newAuthor.LastName = lastName;

            _authorRepository.AddAuthor(newAuthor);


            Console.Write("Enter book's title: ");
            var title = Console.ReadLine();
            Console.Write("Enter book's genre: ");
            var genre = Console.ReadLine();
            var authorId = _authorRepository.GetAllAuthors().Count();

            Book newBook = new Book();
            newBook.Title = title;
            newBook.Genre = genre;
            newBook.AuthorID = authorId;

            _bookRepository.AddBook(newBook);

            Console.WriteLine("The new title has been added successfully");
        }

        private void GetAuthorById()
        {
            Console.Write("Enter author's ID: ");
            var authorId = int.Parse(Console.ReadLine());

            var match = _authorRepository.GetAuthorById(authorId);
            if (match != null)
            {
                Console.WriteLine($"Name: {match.FirstName} Surname: {match.LastName}");
            }
            else
            {
                Console.WriteLine("Sorry no match");
            }
        }

        private void GetBookById()
        {
            Console.Write("Enter book's ID: ");
            var bookId = int.Parse(Console.ReadLine());

            var match = _bookRepository.GetBookById(bookId);

            if (match != null)
            {
                Console.WriteLine($"Title: {match.Title} Genre: {match.Genre}");
            }
            else
            {
                Console.WriteLine("Sorry no match");
            }
        }

        private void GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors().ToList();

            foreach (var author in authors)
            {
                Console.WriteLine($"Name: {author.FirstName} Surname: {author.LastName}");
            }
        }

        private void GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks().ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"Title: \"{book.Title}\" Genre: {book.Genre}");
            }
        }
    }
}
