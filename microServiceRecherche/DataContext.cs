using microServiceRecherche.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microServiceRecherche
{
    public class DataContext : DbContext
    {
        private static DataContext _instance;
        public string ConnectionString { get; set; }

       
        public DbSet<Electrique> Electriques { get; set; }
        public DbSet<Hydraulique> Hydrauliques { get; set; }
        public DbSet<Manuel> Manuels { get; set; }

        public static DataContext GetInstance(string connectionString = null)
        {
            if (_instance == null)
            {
                _instance = new DataContext(connectionString);
                return _instance;
            }
            return _instance;
        }

        private DataContext(string connectionString = null) : base()
        {
            if (connectionString != null)
                ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
                //optionsBuilder.UseSqlServer("Server=tcp:adade.database.windows.net,1433;Initial Catalog=adade;Persist Security Info=False;User ID=architecte;Password=Uqac.2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Electrique>().HasData(new Electrique
            {
                IdElectrique = 1,
                 NomOutil = "Glock",
       Puissance = 12,
         IdOutil = 1,
         Description= "une glock" ,
          Prix =12,
                Stock = 69,

            });
        }
    }
}
