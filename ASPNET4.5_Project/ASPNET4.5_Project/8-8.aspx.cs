using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET4._5_Project {
    public partial class _8_8 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Button1_Click(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            string sqlSelect = "SELECT UserID,Password, Name, Phone From Member";
            string sqlInsert = "Insert Into Member Values (@UserId, @Password, @Name, @Phone)";

            SqlCommand cmdSelect = new SqlCommand(sqlSelect, con);
            SqlCommand cmdInsert = new SqlCommand(sqlInsert, con);
            cmdInsert.Parameters.AddWithValue("@UserID", TextBox1.Text);
            cmdInsert.Parameters.AddWithValue("@Password", TextBox2.Text);
            cmdInsert.Parameters.AddWithValue("@Name", TextBox3.Text);
            cmdInsert.Parameters.AddWithValue("@Phone", TextBox4.Text);

            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmdSelect;
            ad.InsertCommand = cmdInsert;

            DataSet ds = new DataSet();

            ad.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr["UserID"] = TextBox1.Text;
            dr["Password"] = TextBox2.Text;
            dr["Name"] = TextBox3.Text;
            dr["Phone"] = TextBox4.Text;
            dt.Rows.Add(dr);

            ad.Update(ds);

            Label1.Text = "정보가 삽입되었습니다.";

        }
    }
}