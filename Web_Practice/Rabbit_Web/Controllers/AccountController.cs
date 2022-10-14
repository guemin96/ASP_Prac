using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rabbit_Web.DataContext;
using Rabbit_Web.Models;
using Rabbit_Web.ViewModel;
using System.Linq;

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
        [HttpPost]
        public IActionResult Login(LoginViewModel model) 
        {
            //ID, 비밀번호 - 필수
            if (ModelState.IsValid) {

                using (var db = new AspnetNoteDbContext()) {

                    ////Linq - 메서드 체이닝  
                    //var user = db.Users.FirstOrDefault(u=>u.UserId ==model.UserId && u.UserPassword == model.UserPassword);
                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId) && 
                                             u.UserPassword.Equals(model.UserPassword));
                    
                    if (user != null) {
                        //로그인 성공했을때
                        //HttpContext.Session.SetInt32(key, value);
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);

                        return RedirectToAction("LoginSuccess", "Home");            //로그인 성공 페이지로 이동
                    }
                }
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }
        public IActionResult Logout() 
        {
            //HttpContext.Session.Clear();//모든 세션을 삭제(모든 사람들의 로그인 상태를 다 삭제시키므로 사용하지 않음)
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
        }


        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 회원 가입 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid) {

                //Java => try(SqlSession){} catch(){}

                using (var db = new AspnetNoteDbContext()) {
                    db.Users.Add(model);    //메모리까지 올리는 작업
                    db.SaveChanges();       //실제 SQL에 저장하는 작업, Commit 작업
                }
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
    }
}
