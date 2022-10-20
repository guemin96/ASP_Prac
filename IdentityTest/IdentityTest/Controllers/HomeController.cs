using IdentityTest.Data;
using IdentityTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.Controllers {
    public class HomeController : Controller {
        
        public readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public IActionResult Index() {
            //var user = _dbContext.Users.FirstOrDefault();

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
