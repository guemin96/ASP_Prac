using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BOARD_ASP_CORE.Controllers {
    public class BoardController : Controller {
        public IActionResult Index() {
            return View();
        }
        public IActionResult BoardList(int num) {

            num = num.ToString() == "null" ? 1:num;
            DataSet ds = new DataSet();

            string conquery = "Data Source=localhost;Initial Catalog=DotNetNote;User ID=sa;Password=1234";
            using (SqlConnection con = new SqlConnection(conquery)) {
                if (con.State == System.Data.ConnectionState.Closed) {
                    con.Open();
                }
                string query = "Select * from Notes";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ds.Tables.Add(dt);
            }

            return View(ds);
        }
    }
}
