using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class PrizeRepository : IRepository<PrizeDTO>
    {
        private readonly LotoDbContext _context;

        public PrizeRepository(LotoDbContext context)
        {
            _context = context;
        }
        public void Add(PrizeDTO prize)
        {
            _context.Prizes.Add(prize);
            _context.SaveChanges();
        }

        public void Delete(PrizeDTO prize)
        {
            _context.Prizes.Remove(prize);
            _context.SaveChanges();
        }

        public IEnumerable<PrizeDTO> GetAll()
        {
            return _context.Prizes;
        }

        public void Update(PrizeDTO prize)
        {
            _context.Prizes.Update(prize);
            _context.SaveChanges();
        }
    }
}
