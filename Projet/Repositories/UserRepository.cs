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
        public static List<User> GetAll(this DbSet<User> users)
        {
            return users.ToList();
        }

        public static User GetById(this DbSet<User> users, long id)
        {
            return users.FirstOrDefault(u => u.UserId == id);
        }

        public static void RemoveById(this DbSet<User> users, long id)
        {
            users.Remove(users.GetById(id));
        }
    }
}
