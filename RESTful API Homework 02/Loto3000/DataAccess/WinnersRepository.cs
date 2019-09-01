using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class WinnersRepository : IRepository<WinnersDTO>
    {
        private readonly LotoDbContext _context;

        public WinnersRepository(LotoDbContext context)
        {
            _context = context;
        }
        public void Add(WinnersDTO user)
        {
            _context.Winners.Add(user);
            _context.SaveChanges();
        }

        public void Delete(WinnersDTO user)
        {
            _context.Winners.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<WinnersDTO> GetAll()
        {
            return _context.Winners;
        }

        public void Update(WinnersDTO user)
        {
            _context.Winners.Update(user);
            _context.SaveChanges();
        }
    }
}
