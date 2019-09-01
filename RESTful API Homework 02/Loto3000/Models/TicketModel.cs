using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string Numbers { get; set; }
    }
}
