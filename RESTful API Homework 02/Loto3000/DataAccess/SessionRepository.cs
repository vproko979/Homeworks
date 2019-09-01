using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class SessionRepository : IRepository<SessionDTO>
    {
        private readonly LotoDbContext _context;

        public SessionRepository(LotoDbContext context)
        {
            _context = context;
        }
        public void Add(SessionDTO session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        public void Delete(SessionDTO session)
        {
            _context.Sessions.Remove(session);
            _context.SaveChanges();
        }

        public IEnumerable<SessionDTO> GetAll()
        {
            return _context.Sessions;
        }

        public void Update(SessionDTO session)
        {
            _context.Sessions.Update(session);
            _context.SaveChanges();
        }
    }
}
