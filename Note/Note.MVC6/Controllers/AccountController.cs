using Microsoft.AspNetCore.Mvc;
using Note.Model;
using Note.ViewModel;

namespace Note.MVC6.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 로그인 전송
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var id = model.UserId;
                var password = model.Password;
            }
            return View();
        }
    }
}
