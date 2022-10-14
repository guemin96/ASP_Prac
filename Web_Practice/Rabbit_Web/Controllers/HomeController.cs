using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rabbit_Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Rabbit_Web.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {

            var firstUser = new User();
            firstUser.UserNo = 1;
            firstUser.UserName = "홍길동";

            //1번째 방식
            //return View(firstUser);

            //2번째 방식
            ViewBag.User2 = firstUser;

            //3번째 방식
            ViewData["UserNo"] = firstUser.UserNo ;
            ViewData["UserName"] = firstUser.UserName;

            return View(firstUser);
        } 

        public IActionResult LoginSuccess() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
