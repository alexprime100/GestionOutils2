using Microsoft.AspNetCore.Mvc;
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
        public IActionResult SaveUser(long id, string name, string firstname, string adress, DateTime dob, string phone, string email, bool role = false)
        {
            Console.Write("\n\nTEST\n\n");

            Console.Write(role);
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
                Console.WriteLine(e);
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
    }
}
