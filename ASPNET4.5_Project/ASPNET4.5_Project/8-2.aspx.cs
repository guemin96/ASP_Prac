using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET4._5_Project {
    public partial class _8_2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Button1_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            string sql = "SELECT UserID,Password,Name,Phone From Member Where UserID = @UserID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@UserID", TextBox1.Text);

            con.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read()) {
                Label1.Text += String.Format("{0},{1},{2},{3}<br/>", rd["UserID"], rd["Password"], rd["Name"], rd["Phone"]);
            }

            rd.Close();
            con.Close();

        }
    }
}