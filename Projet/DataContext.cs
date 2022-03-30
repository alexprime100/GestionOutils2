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
        private static DataContext _instance;
        public string ConnectionString { get; set; }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Achat> Achats { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Electrique> Electriques { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<Hydraulique> Hydrauliques { get; set; }
        public DbSet<Inventaire> Inventaires { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Manuel> Manuels { get; set; }
        public DbSet<Outil> Outils { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Particulier> Particuliers { get; set; }

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


        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

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
            modelBuilder.Entity<Utilisateur>().HasData(new Utilisateur
            {
                Id = 1,
                Nom = "user",
                Prenom = "user",
                Courriel = "user@mail.com",
                Adresse = "adress1",
                Telephone = "111",
                DateNaissance = DateTime.Now,
                MotDePasse = UserSecurity.Hash("azert", "user@mail.com"),
                Role = "User"
            }, new Utilisateur()
            {
                Id = 2,
                Nom = "admin",
                Prenom = "admin",
                Courriel = "admin@mail.com",
                Adresse = "adress2",
                Telephone = "222",
                DateNaissance = DateTime.Now,
                MotDePasse = UserSecurity.Hash("azert", "admin@mail.com"),
                Role = "Admin"
            });
        }
    }
}
