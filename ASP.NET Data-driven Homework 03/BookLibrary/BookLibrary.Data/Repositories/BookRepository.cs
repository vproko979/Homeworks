using BookLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(Book book)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                context.Books.Add(book);

                context.SaveChanges();
            }
        }

        public void DeleteBook(int Id)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                var book = context.Books.FirstOrDefault(b => b.Id == Id);
                context.Books.Remove(book);

                context.SaveChanges();
            }
        }

        public void EditBook(Book book)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                var match = context.Books.FirstOrDefault(b => b.Id == book.Id);
                match.Title = book.Title;
                match.Genre = book.Genre;
                match.AuthorID = book.AuthorID;

                context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                return context.Books.ToList();
            }
        }

        public Book GetBookById(int Id)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                return context.Books.FirstOrDefault(b => b.Id == Id);
            }
        }
    }
}
