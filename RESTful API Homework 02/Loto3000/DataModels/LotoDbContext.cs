using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DataModels
{
    public class LotoDbContext : DbContext
    {
        public LotoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserDTO> Users { get; set; }
        public DbSet<SessionDTO> Sessions { get; set; }
        public DbSet<TicketDTO> Tickets { get; set; }
        public DbSet<DrawingDTO> Drawings { get; set; }
        public DbSet<WinnersDTO> Winners { get; set; }
        public DbSet<PrizeDTO> Prizes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            builder.Entity<UserDTO>()
                .HasData(
                new UserDTO()
                {
                    Id = 1,
                    Username = "bob007",
                    Password = hashedPassword,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Role = "Admin"
                });

            builder.Entity<PrizeDTO>()
                .HasData(
                new PrizeDTO()
                {
                    Id = 1,
                    NumberOfHits = 3,
                    Prize = "50$ Gift Card"
                },
                new PrizeDTO()
                {
                    Id = 2,
                    NumberOfHits = 4,
                    Prize = "100$ Gift Card"
                },
                new PrizeDTO()
                {
                    Id = 3,
                    NumberOfHits = 5,
                    Prize = "TV"
                },
                new PrizeDTO()
                {
                    Id = 4,
                    NumberOfHits = 6,
                    Prize = "Vacation"
                },
                new PrizeDTO()
                {
                    Id = 5,
                    NumberOfHits = 7,
                    Prize = "(JackPot) - Car"
                });
        }
    }
}
