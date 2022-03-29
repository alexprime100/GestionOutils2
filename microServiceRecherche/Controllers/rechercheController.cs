using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using microServiceRecherche.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


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

        // GET: api/recherche/5
        [HttpGet("{name}", Name = "Get")]
        public IQueryable<Electrique> Get(string name)
        {
            Debug.WriteLine("Send to debug output.");
            return db.Electriques.Where( elec => elec.NomOutil.Contains(name));
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
