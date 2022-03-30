﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Projet.Extensions;
using Projet.Models;
using Projet.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projet.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext db;

        public UserController()
        {
            db = DataContext.GetInstance();
        }

        public IActionResult Admin()
        {
            List<Utilisateur> list = db.Utilisateurs.ToList();
            return View(list);
        }

        [HttpGet("edituser")]
        public IActionResult EditUser(long id)
        {
            Utilisateur user = db.Utilisateurs.GetById(id);
            return View(user);
        }

        [HttpPost("edituser")]
        public IActionResult SaveUser(long id, string name, string firstname, string adress, DateTime dob, string phone, string email, bool role)
        {
            try
            {
                Utilisateur user = db.Utilisateurs.GetById(id);
                if (!user.Nom.Equals(name)) user.Nom = name;
                if (!user.Prenom.Equals(firstname)) user.Prenom = firstname;
                if (!user.Adresse.Equals(adress)) user.Adresse = adress;
                if (!user.DateNaissance.IsSame(dob)) user.DateNaissance = dob;
                if (!user.Telephone.Equals(phone)) user.Telephone = phone;
                if (!user.Courriel.Equals(email)) user.Courriel = email;
                user.Role = role ? "Admin" : "User";

                db.Utilisateurs.Update(user);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }

            return RedirectToAction("Admin");
        }

        //[HttpPost("delete")]
        public IActionResult DeleteUser(long id)
        {
            db.Utilisateurs.RemoveById(id);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }

        [HttpGet("editelec")]
        public IActionResult EditElec(long id)
        {
            Electrique electrique = db.Electriques.GetById(id);
            return View(electrique);
        }

        [HttpPost("editElec")]
        public IActionResult SaveElec(long id, string name, long puissance, string description, double prix, int stock)
        {
            try
            {
                
                Electrique electrique = db.Electriques.GetById(id);
                if (!electrique.NomOutil.Equals(name)) electrique.NomOutil = name;
                if (!electrique.Puissance.Equals(puissance)) electrique.Puissance = puissance;
                if (!electrique.Description.Equals(description)) electrique.Description = description;
                if (!electrique.Prix.Equals(prix)) electrique.Prix = prix;
                if (!electrique.Stock.Equals(stock)) electrique.Stock = stock;

                db.Electriques.Update(electrique);
                db.SaveChanges();
            }
            catch(Exception e)
            {

            }
            return RedirectToAction("Admin");
        }
    }
}
