using BOARD_ASP_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System;

namespace BOARD_ASP_CORE.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private SqlConnection con;


        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        private readonly IConfiguration _configuration;

        public IActionResult Index() {

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }
        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string UserId, string UserPassword) {

            string conquery = "Data Source=localhost;Initial Catalog=DotNetNote;User ID=sa;Password=1234";
            using (con = new SqlConnection(conquery)) {
                if (con.State == ConnectionState.Closed) {
                    con.Open();
                }

                string query = "select * from TB_User where Id=@Id and Password=@Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = UserId;
                cmd.Parameters.Add("@Password",SqlDbType.NVarChar).Value = UserPassword;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                if (dt.Rows.Count!=0) {
                    HttpContext.Session.SetInt32("USER_LOGIN_KEY", Int32.Parse(dt.Rows[0]["Num"].ToString()) );

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string UserId, string UserPassword)
        {
            if (UserId != null && UserPassword != null)
            {
                string conquery = "Data Source=localhost;Initial Catalog=DotNetNote;User ID=sa;Password=1234";
                using (con = new SqlConnection(conquery))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string query = "insert into TB_User (Id,Password) values (@ID,@Password)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = UserId;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = UserPassword;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return View();
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
