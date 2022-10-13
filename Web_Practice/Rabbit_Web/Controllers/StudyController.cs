using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Rabbit_Web.Controllers {
    public class StudyController : Controller {
        // GET: StudyController
        public IActionResult Index() {
            return View();
        }
        public IActionResult Java() {
            return View();
        }
        public IActionResult CSharp() {
            return View();
        }
        public IActionResult CPP() {
            return View();
        }
    }
}
