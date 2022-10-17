using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Note.MVC6.Models;
using System.Diagnostics;
using Note.BLL;
using Note.DAL;

namespace Note.MVC6.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserBll _userBll;

        //public HomeController()
        //{

        //}

        public HomeController(UserBll userBll)
        {
            _userBll = userBll;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var user = _userBll.GetUser(1); 
            return View();
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
