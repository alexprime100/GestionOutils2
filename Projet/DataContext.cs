using Microsoft.EntityFrameworkCore;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:adade.database.windows.net,1433;Initial Catalog=adade;Persist Security Info=False;User ID=architecte;Password=Uqac.2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                UserName = "user",
                UserFirstName = "user",
                UserEmail = "user@mail.com",
                UserAdress = "adress1",
                UserDateOfBirth = DateTime.Now,
                UserPassword = Program.Hash("azert", "user@mail.com"),
                UserRole = "User"
            }, new User()
            {
                UserId = 2,
                UserName = "admin",
                UserFirstName = "admin",
                UserEmail = "admin@mail.com",
                UserAdress = "adress2",
                UserDateOfBirth = DateTime.Now,
                UserPassword = Program.Hash("azert", "admin@mail.com"),
                UserRole = "Admin"
            });
        }
    }
}
