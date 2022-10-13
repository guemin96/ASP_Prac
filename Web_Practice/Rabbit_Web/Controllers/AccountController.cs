using Microsoft.AspNetCore.Mvc;
using Rabbit_Web.Models;

namespace Rabbit_Web.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Login()
        //{
        //    return View();
        //}
        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            return View();
        }
        //8강 38분
    }
}
