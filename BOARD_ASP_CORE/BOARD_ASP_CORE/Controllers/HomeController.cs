using BOARD_ASP_CORE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BOARD_ASP_CORE.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private SqlConnection con;


        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        private readonly IConfiguration _configuration;

        public IActionResult Index() {

            //if (HttpContext.Session.GetString("USER_LOGIN_KEY")==null) {

            //}


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

                string query = "select Id,Password from TB_User where @Id=";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = UserId;
                cmd.Parameters.Add("@Password",SqlDbType.NVarChar).Value = UserPassword;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                var user = dt.AsEnumerable().FirstOrDefault(u => u[0].Equals(UserId) &&
                                                                 u[1].Equals(UserPassword));
                if (user != null) {
                    HttpContext.Session.SetString("USER_LOGIN_KEY", user[0].ToString());

                    return RedirectToAction("Index", "Home");
                }


            }
            
            


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
