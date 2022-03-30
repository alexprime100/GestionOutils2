using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Projet;
using Projet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace microServiceRecherche.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class rechercheController : ControllerBase
    {

        private DataContext db = DataContext.GetInstance();

        // GET: api/recherche
        [HttpGet]
        public List<Electrique> Get()
        {
            return db.Electriques.ToList();
        }

        // GET: api/recherche/glo
        [HttpGet("advanced/{name}", Name = "advanced")]
        public String advanced(string name)
        {
            IQueryable<Object> electrique = db.Electriques.Where(elec => elec.NomOutil.Contains(name));
            IQueryable<Object> hydraulique = db.Hydrauliques.Where(elec => elec.NomOutil.Contains(name));
            // TODO IQueryable<Hydraulique> manuel = db.Manuels.Where(elec => elec.NomOutil.Contains(name));
            var jsonElectrique = JsonConvert.SerializeObject(electrique.ToArray());
            var jsonHydraulique = JsonConvert.SerializeObject(hydraulique.ToArray());

            return String.Concat(jsonElectrique,jsonHydraulique);
            }

        // GET: api/recherche/glo
        [HttpGet("advanced", Name = "advancedDefault")]
        public String advancedDefault()
        {
            List<Electrique> electrique = db.Electriques.ToList(); 
            List<Hydraulique> hydraulique = db.Hydrauliques.ToList(); 
            // TODO IQueryable<Hydraulique> manuel = db.Manuels.Where(elec => elec.NomOutil.Contains(name));
            var jsonElectrique = JsonConvert.SerializeObject(electrique.ToArray());
            var jsonHydraulique = JsonConvert.SerializeObject(hydraulique.ToArray());

            return String.Concat(jsonElectrique, jsonHydraulique);
        }

        // GET: api/recherche/glo
        [HttpGet("electrique/{name}", Name = "electrique")]
        public String electrique(string name)
        {
            IQueryable<Object> electrique = db.Electriques.Where(elec => elec.NomOutil.Contains(name));
            var jsonElectrique = JsonConvert.SerializeObject(electrique.ToArray());

            return jsonElectrique;
        }

        // GET: api/recherche/glo
        [HttpGet("electrique", Name = "electriqueDefault")]
        public String electriqueDefault()
        {
            List<Electrique> electrique = db.Electriques.ToList();
            var jsonElectrique = JsonConvert.SerializeObject(electrique.ToArray());

            return jsonElectrique;
        }

        // POST: api/recherche
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/recherche/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
