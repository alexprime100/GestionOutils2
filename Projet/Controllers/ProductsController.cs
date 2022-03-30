﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projet.Extensions;
using Projet.Models;
using Projet.Repositories;

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

        [HttpGet("editElec")]
        public IActionResult EditElec(long id)
        {
            Electrique elec = db.Electriques.GetElecById(id);
            return View(elec);
        }

        
        [HttpPost("editElec")]
        public IActionResult Save(long id, string nom, long puissance, double prix ,int stock, Byte[] image)
        {

            Console.WriteLine(id + " " + nom + " " + puissance + " " + prix + " " + stock);

            try
            {
                Electrique elec = db.Electriques.GetElecById(id);
                Console.WriteLine(elec.ToString());
                if (!elec.NomOutil.Equals(nom)) elec.NomOutil = nom;
                if (!elec.Puissance.Equals(puissance)) elec.Puissance = puissance;
                if (!elec.Prix.Equals(prix)) elec.Prix = prix;
                if (!elec.Stock.Equals(stock)) elec.Stock = stock;
                //if (!elec.Image.Equals(image)) elec.Image = image.getByte();
              
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
            return RedirectToAction("Admin");
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
        public IActionResult AddElec(long id, long idOutils, string nom, long puissance, double prix, int stock, string description, Byte[] image)
        {

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
    }
}