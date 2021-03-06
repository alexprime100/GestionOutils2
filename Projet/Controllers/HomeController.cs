using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text.Json;

namespace Projet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext db;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            db = DataContext.GetInstance();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            ViewData["ReturnUrl"] = "Home/Login";
            return View();
        }

        [HttpGet("search")]
        public IActionResult Search(string keyword, string searchField)
        {
            string toolsJson = searchField switch
            {
                "all" => AdvancedSearch(keyword),
                "electric" => ElectricSearch(keyword),
                "hydraulic" => HydraulicSearch(keyword),
                _ => "",
            };
            if (toolsJson.Contains("[]")) // Si on a des objets soit électriques, soit hydralique
                toolsJson = toolsJson.Replace("[]", "");
            else if (toolsJson.Contains("][")) // Si on a des objets électriques et hydraulique
                toolsJson = toolsJson.Replace("][", ",");

            if (toolsJson.Length == 0)
                ViewData["Tools"] = new List<OutilObjet>();
            else
                ViewData["Tools"] = JsonSerializer.Deserialize<List<OutilObjet>>(toolsJson);

            return View("index");
        }

        [HttpGet("advancedSearch")]
        public string AdvancedSearch(string keyword)
        {
            var responseString = ApiCall.GetApi("https://localhost:31661/api/recherche/advanced/" + keyword);
            return responseString;
        }

        [HttpGet("electricSearch")]
        public string ElectricSearch(string keyword)
        {
            var responseString = ApiCall.GetApi("https://localhost:31661/api/recherche/electrique/" + keyword);
            return responseString;
        }

        [HttpGet("hydraulicSearch")]
        public string HydraulicSearch(string keyword)
        {
            var responseString = ApiCall.GetApi("https://localhost:31661/api/recherche/hydraulique/" + keyword);
            return responseString;
        }

        [HttpPost("register")]
        public IActionResult SignUp(string firstName, string name, string adress, string email, string phone, DateTime dob, string password, string password2)
        {
            try
            {
                UserSecurity.Verification(email, password, password2);
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return View("register");
            }
            string hashedPassword = UserSecurity.Hash(password, email);
            Utilisateur newUser = new Utilisateur
            {
                Prenom = firstName,
                Nom = name,
                Adresse = adress,
                Courriel = email,
                Telephone = phone,
                DateNaissance = dob,
                MotDePasse = hashedPassword,
                Role = "User"
            };
            try
            {
                if (db.Utilisateurs.Count(u => u.Courriel == email) == 0)
                {
                    db.Utilisateurs.Add(newUser);
                    db.SaveChanges();
                }
                else
                {
                    TempData["Error"] = "Error, another account with same email already exists";
                    return View("register");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Redirect("/Login");
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl = "/Home/Index")
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Validate(string email, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            string hashedPassword = UserSecurity.Hash(password, email);

            try
            {
                Utilisateur user = db.Utilisateurs.FirstOrDefault(u => u.Courriel == email && u.MotDePasse == hashedPassword);

                if (user != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, email));
                    claims.Add(new Claim(ClaimTypes.Name, user.Prenom + " " + user.Nom));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return Redirect(returnUrl);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            TempData["Error"] = "Error, invalid username or password";
            return View("login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
