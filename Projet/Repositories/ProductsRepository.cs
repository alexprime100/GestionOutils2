using Microsoft.EntityFrameworkCore;
using Projet.Models;
using System.Linq;


namespace Projet.Repositories
{
    public static class ProductsRepository
    {

        public static Electrique GetElecById(this DbSet<Electrique> elec, long id)
        {
            return elec.FirstOrDefault(u => u.IdElectrique == id);
        }

        public static Hydraulique GetHydrauById(this DbSet<Hydraulique> hydrau, long id)
        {
            return hydrau.FirstOrDefault(u => u.IdOutil == id);
        }

        public static void RemoveElecById(this DbSet<Electrique> elec, long id)
        {
            elec.Remove(elec.GetElecById(id));
        }

        public static void RemoveHydrauById(this DbSet<Hydraulique> hydrau, long id)
        {
            hydrau.Remove(hydrau.GetHydrauById(id));
        }
    }
}
