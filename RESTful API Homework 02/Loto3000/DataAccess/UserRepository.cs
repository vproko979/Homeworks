using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class UserRepository : IRepository<UserDTO>
    {
        private readonly LotoDbContext _context;

        public UserRepository(LotoDbContext context)
        {
            _context = context;
        }
        public void Add(UserDTO user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(UserDTO user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _context.Users;
        }

        public void Update(UserDTO user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
