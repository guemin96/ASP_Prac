using BasicBoard.Data;
using BasicBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BasicBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var loginUser = _db.Users.FromSql($"SELECT * FROM Users WHERE UserId = {user.UserId} AND Password = {user.Password} ").FirstOrDefault();

            if (loginUser != null)
            {
                HttpContext.Session.SetInt32("USER_LOGIN_KEY", loginUser.Id);
                HttpContext.Session.SetString("USER_NAME", loginUser.UserName);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            HttpContext.Session.Remove("USER_NAME");

            return RedirectToAction("Index", "Home");

        }

        public IActionResult Signup()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password == user.PasswordCheck)
                {
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    TempData["success"] = "User added successfully";

                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

            public IActionResult Privacy()
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