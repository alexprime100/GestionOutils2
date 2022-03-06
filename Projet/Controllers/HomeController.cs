using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<DataContext> _dataSettings;

        public HomeController(ILogger<HomeController> logger, IOptions<DataContext> options)
        {
            _logger = logger;
            _dataSettings = options;
        }

        public IActionResult Index()
        {
            ViewData["ConnectionString"] = _dataSettings.Value.ConnectionString;
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

        [HttpPost("register")]
        public IActionResult SignUp(string firstName, string name, string adress, string email, string phone, DateTime dob, string password, string password2)
        {
            if (!password.Equals(password2))
            {
                TempData["Error"] = "Error, the passwords are not identical";
                return View("register");
            }
            string hashedPassword = Program.Hash(password, email);
            User newUser = new User
            {
                UserFirstName = firstName,
                UserName = name,
                UserAdress = adress,
                UserEmail = email,
                UserPhoneNumber = phone,
                UserDateOfBirth = dob,
                UserPassword = hashedPassword,
                UserRole = "User"
            };
            try
            {
                var db = new DataContext();
                if (db.Users.Count(u => u.UserEmail == email) == 0)
                {
                    db.Users.Add(newUser);
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
            string hashedPassword = Program.Hash(password, email);
            var db = new DataContext();

            try
            {
                User user = db.Users.FirstOrDefault(u => u.UserEmail == email && u.UserPassword== hashedPassword);

                if (user != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, email));
                    claims.Add(new Claim(ClaimTypes.Name, user.UserFirstName + " " + user.UserName));
                    claims.Add(new Claim(ClaimTypes.Role, user.UserRole));
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
