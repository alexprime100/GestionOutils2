using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Projet.Extensions;
using Projet.Models;
using Projet.Repositories;
using System.Web;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projet.Controllers
{
    public class ProductsController : Controller
    {

        private readonly DataContext db;

        public ProductsController()
        {
            db = DataContext.GetInstance();
        }

        [HttpGet("descritionElec")]
        public IActionResult DescriptionElec(long id)
        {
            Electrique elec = db.Electriques.GetElecById(id);
            return View(elec);
        }

        [HttpGet("editElec")]
        public IActionResult EditElec(long id)
        {
            Electrique elec = db.Electriques.GetElecById(id);
            return View(elec);
        }

        
        [HttpPost("editElec")]
        public IActionResult Save(long id, string nom, long puissance, double prix, string description ,int stock, IFormFile file)
        {
            try
            {
                byte[] image;
                using (var target = new MemoryStream())
                {
                    if (file != null)
                    {
                        file.CopyTo(target);
                        image = target.ToArray();
                    }
                    else
                    {
                        image = null;
                    }
                   
                }


                Electrique elec = db.Electriques.GetElecById(id);
                if (image == null)
                {
                    image = elec.Image;
                }
                Console.WriteLine(elec.ToString());
                if (!elec.NomOutil.Equals(nom)) elec.NomOutil = nom;
                if (!elec.Puissance.Equals(puissance)) elec.Puissance = puissance;
                if (!elec.Prix.Equals(prix)) elec.Prix = prix;
                if (!elec.Description.Equals(description)) elec.Description = description;

                if (!elec.Stock.Equals(stock)) elec.Stock = stock;
                if (!elec.Image.Equals(image)) elec.Image = image;

                db.Electriques.Update(elec);
                db.SaveChanges();

            }
                
           
            catch (Exception e)
            {

                throw e;
            }

            return RedirectToAction("ListProducts");
        }
     
  

        public IActionResult DeleteHydrau(long id)
        {
            db.Hydrauliques.RemoveHydrauById(id);
            db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        //[HttpPost("deleteElec")]
        public IActionResult DeleteElec(long id)
        {
            db.Electriques.RemoveElecById(id);
            db.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        [HttpGet("ListProducts")]
        public IActionResult ListProducts()
        {
            ViewData["ReturnUrl"] = "ListProducts";
            return View();
        }

        [HttpGet("AddElec")]
        public IActionResult AddElec()
        {
            ViewData["ReturnUrl"] = "AddElec";
            return View();
        }

        [HttpPost("AddElec")]
        public IActionResult AddElec(long id, long idOutils, string nom, long puissance, double prix, int stock, string description, IFormFile file)
        {
            byte[] image;
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                image = target.ToArray();
            }

            Electrique newElec = new Electrique
            {
                IdElectrique = id,
                IdOutil = idOutils,
                NomOutil = nom,
                Prix = prix,
                Description = description,
                Stock = stock,
                Puissance = puissance,
                Image = image,
            };
            try
            {

                db.Electriques.Add(newElec);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("ListProducts");

        }


        [HttpGet("AddHydrau")]
        public IActionResult AddHydrau()
        {
            ViewData["ReturnUrl"] = "AddHydrau";
            return View();
        }

        [HttpPost("AddHydrau")]
        public IActionResult AddHydrau(long id, long idOutils, string nom, long pression, double prix, int stock, string description, IFormFile file)
        {
            byte[] image;
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                image = target.ToArray();
            }
            Hydraulique newHydrau = new Hydraulique
            {
                IdHydraulique = id,
                IdOutil = idOutils,
                NomOutil = nom,
                Prix = prix,
                Description = description,
                Stock = stock,
                Pression = pression,
                Image = image,
            };
            try
            {

                db.Hydrauliques.Add(newHydrau);
                db.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("ListProducts");

        }

        [HttpGet("editHydrau")]
        public IActionResult EditHydrau(long id)
        {
            Hydraulique hydrau = db.Hydrauliques.GetHydrauById(id);
            return View(hydrau);
        }


        [HttpPost("editHydrau")]
        public IActionResult Save(long id, string nom, long pression,string description, double prix, int stock, IFormFile file)
        {
            try
            {
                byte[] image;
                using (var target = new MemoryStream())
                {
                    if (file != null)
                    {
                        file.CopyTo(target);
                        image = target.ToArray();
                    }
                    else
                    {
                        image = null;
                    }
                }

                Hydraulique hydrau = db.Hydrauliques.GetHydrauById(id);
                if (image == null)
                {
                    image = hydrau.Image;
                }
                Console.WriteLine(hydrau.ToString());
                if (!hydrau.NomOutil.Equals(nom)) hydrau.NomOutil = nom;
                if (!hydrau.Pression.Equals(pression)) hydrau.Pression = pression;
                if (!hydrau.Prix.Equals(prix)) hydrau.Prix = prix;
                if (!hydrau.Description.Equals(description)) hydrau.Description = description;
                if (!hydrau.Stock.Equals(stock)) hydrau.Stock = stock;
                if (!hydrau.Image.Equals(image)) {
                    hydrau.Image = image;
                }

                db.Hydrauliques.Update(hydrau);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }

            return RedirectToAction("ListProducts");
        }
    }
}
