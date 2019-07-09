using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();

        Book GetBookById(int Id);

        void AddBook(Book book);

        void DeleteBook(int Id);

        void EditBook(Book book);
    }
}
