using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class DrawingRepository : IRepository<DrawingDTO>
    {
        private readonly LotoDbContext _context;

        public DrawingRepository(LotoDbContext context)
        {
            _context = context;
        }
        public void Add(DrawingDTO drawing)
        {
            _context.Drawings.Add(drawing);
            _context.SaveChanges();
        }

        public void Delete(DrawingDTO drawing)
        {
            _context.Drawings.Remove(drawing);
            _context.SaveChanges();
        }

        public IEnumerable<DrawingDTO> GetAll()
        {
            return _context.Drawings;
        }

        public void Update(DrawingDTO drawing)
        {
            _context.Drawings.Update(drawing);
            _context.SaveChanges();
        }
    }
}
