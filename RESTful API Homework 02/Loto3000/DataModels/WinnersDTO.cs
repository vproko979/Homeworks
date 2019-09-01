using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels
{
    public class WinnersDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public int Hits { get; set; }
        public string Prize { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WinningNumbers { get; set; }
    }
}
