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
    public partial class _8_7 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);

            string sql = "SELECT UserID,Password, Name, Phone From Member";
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;

            DataSet ds = new DataSet();

            ad.Fill(ds);

            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++) {
                Label1.Text += String.Format("{0},{1},{2},{3}<br/>", dt.Rows[i]["UserID"], dt.Rows[i]["Password"], dt.Rows[i]["Name"], dt.Rows[i]["Phone"]);
            }
            DropDownList1.DataSource = ds;
            DropDownList1.DataValueField = "UserID";
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataBind();

        }
    }
}