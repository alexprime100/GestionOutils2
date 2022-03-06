using Microsoft.EntityFrameworkCore;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Repositories
{
    public static class UserRepository
    {
        public static List<Utilisateur> GetAll(this DbSet<Utilisateur> users)
        {
            return users.ToList();
        }

        public static Utilisateur GetById(this DbSet<Utilisateur> users, long id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public static void RemoveById(this DbSet<Utilisateur> users, long id)
        {
            users.Remove(users.GetById(id));
        }
    }
}
