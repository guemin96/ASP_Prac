using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET4._5_Project {
    public partial class _8_11 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

            string sql = "SELECT UserID,Password, Name, Phone From Member";

            SqlCommand cmd= new SqlCommand(sql, con);
            con.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            Repeater1.DataSource = rd;
            Repeater1.DataBind();

            rd.Close();
            con.Close();

        }
    }
}