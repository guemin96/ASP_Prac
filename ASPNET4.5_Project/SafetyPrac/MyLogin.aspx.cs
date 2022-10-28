using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace SafetyPrac {
    public partial class MyLogin : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Button1_Click(object sender, EventArgs e) {
            if (IsAuthenticated(TextBox1.Text,TextBox2.Text)) 
            {
                FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, CheckBox1.Checked);
            }
            else {
                Label1.Text = "아이디와 암호가 일치하지 않습니다.";
            }
        }
        bool IsAuthenticated(string userID, string password) {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            string sql = "SELECT COUNT(UserID) From Member Where UserID =@UserID and Password = @Password";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@Password", password);
            con.Open();

            int count = (int)cmd.ExecuteScalar();
            con.Close();

            return count > 0;
        }
    }
}