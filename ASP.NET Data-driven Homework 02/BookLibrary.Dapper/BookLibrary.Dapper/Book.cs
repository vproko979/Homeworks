using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Dapper
{
    public class Book
    {
        public string Title { get; set; } 
        public string Genre { get; set; } 
        public int AuthorID { get; set; }

        public virtual Author Author { get; set; }
    }
}
