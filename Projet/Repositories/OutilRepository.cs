using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projet.Models;

namespace Projet.Repositories
{
    public static class OutilRepository
    {
        public static Electrique GetById(this DbSet<Electrique> electriques, long id)
        {
            return electriques.FirstOrDefault(x => x.IdElectrique == id);
        }

        public static void RemoveById(this DbSet<Electrique> electriques, long id)
        {
            electriques.Remove(electriques.GetById(id));
        }

        public static Hydraulique GetById(this DbSet<Hydraulique> hydrauliques, long id)
        {
            return hydrauliques.FirstOrDefault(x => x.IdHydraulique == id);
        }

        public static void RemoveById(this DbSet<Hydraulique> hydrauliques, long id)
        {
            hydrauliques.Remove(hydrauliques.GetById(id));
        }

        public static Manuel GetById(this DbSet<Manuel> manuels, long id)
        {
            return manuels.FirstOrDefault(x => x.IdManuel == id);
        }

        public static void RemoveById(this DbSet<Manuel> manuels, long id)
        {
            manuels.Remove(manuels.GetById(id));
        }
    }
}
