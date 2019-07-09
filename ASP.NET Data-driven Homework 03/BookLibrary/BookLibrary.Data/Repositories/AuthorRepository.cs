using BookLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public void AddAuthor(Author author)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                context.Authors.Add(author);

                context.SaveChanges();
            }
        }

        public void DeleteAuthor(int Id)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                var match = context.Authors.FirstOrDefault(a => a.Id == Id);
                context.Authors.Remove(match);

                context.SaveChanges();
            }
        }

        public void EditAuthor(Author author)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                var match = context.Authors.FirstOrDefault(a => a.Id == author.Id);
                match.FirstName = author.FirstName;
                match.LastName = author.LastName;

                context.SaveChanges();
            }
        }

        public List<Author> GetAllAuthors()
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                return context.Authors.ToList();
            }
        }

        public Author GetAuthorById(int Id)
        {
            using (AdoNetDBEntities context = new AdoNetDBEntities())
            {
                return context.Authors.FirstOrDefault(a => a.Id == Id);
            }
        }
    }
}
