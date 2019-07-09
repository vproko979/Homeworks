using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Interfaces
{
    public interface IAuthorRepository
    {
        List<Author> GetAllAuthors();

        Author GetAuthorById(int Id);

        void AddAuthor(Author author);

        void DeleteAuthor(int Id);

        void EditAuthor(Author author);
    }
}
