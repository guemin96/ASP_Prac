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
        //string conquery = "Data Source=localhost;Initial Catalog=DotNetNote;User ID=sa;Password=1234";
        string conquery = string.Empty;

        private readonly IConfiguration configuration;
        public IDbConnection dbConnection { get;}



        public HomeController(ILogger<HomeController> logger, IConfiguration configuration) {
            _logger = logger;
            this.configuration = configuration;
            this.dbConnection = new SqlConnection(this.configuration.GetConnectionString("ConnectionString"));
            conquery = dbConnection.ConnectionString;
        }


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
        public IActionResult Login(UserM model) {

            using (con = new SqlConnection(conquery)) {
                if (con.State == ConnectionState.Closed) {
                    con.Open();
                }

                string query = "select * from TB_User where Id=@Id and Password=@Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = model.Id;
                cmd.Parameters.Add("@Password",SqlDbType.NVarChar).Value = model.Password;
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
        public IActionResult Register(UserM model)
        {
            if (ModelState.IsValid) {
                if (model.Password == model.ChkPassword) {
                    using (con = new SqlConnection(conquery)) {
                        if (con.State == ConnectionState.Closed) {
                            con.Open();
                        }
                        string query = "insert into TB_User (Id,Password,Name,Gender,Birthday,Email,Phone,Address) values (@ID,@Password,@Name,@Gender,@Birthday,@Email,@Phone,@Address)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = model.Id;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = model.Password;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = model.Name;
                        cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = model.Gender;
                        cmd.Parameters.Add("@Birthday", SqlDbType.NVarChar).Value = model.Birthday;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value =  String.IsNullOrEmpty(model.Email)? "":model.Email;
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = String.IsNullOrEmpty(model.Phone) ? "" : model.Phone;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = model.Address;

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    return RedirectToAction("Login", "Home");
                }
                else {
                    return View();
                }
            }
            else {
                return View();
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
