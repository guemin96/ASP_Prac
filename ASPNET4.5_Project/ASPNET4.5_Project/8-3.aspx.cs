using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET4._5_Project {
    public partial class _8_3 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Button1_Click(object sender, EventArgs e) {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            string sql = "INSERT INTO Member Values( @Password,@Name, @Phone)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Password", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Name", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Phone", TextBox4.Text);

            con.Open();

            cmd.ExecuteNonQuery();
            con.Close();

            Label1.Text = TextBox1.Text + "의 정보가 입력되었습니다.";

        }
    }
}