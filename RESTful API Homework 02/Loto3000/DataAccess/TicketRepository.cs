using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class TicketRepository : IRepository<TicketDTO>
    {
        private readonly LotoDbContext _context;

        public TicketRepository(LotoDbContext context)
        {
            _context = context;
        }
        public void Add(TicketDTO ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void Delete(TicketDTO ticket)
        {
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }

        public IEnumerable<TicketDTO> GetAll()
        {
            return _context.Tickets;
        }

        public void Update(TicketDTO ticket)
        {
            _context.Tickets.Update(ticket);
            _context.SaveChanges();
        }
    }
}
