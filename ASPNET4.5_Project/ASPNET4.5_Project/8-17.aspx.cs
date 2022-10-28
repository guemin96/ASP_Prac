using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET4._5_Project {
    public partial class _8_17 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            string sql = "SELECT M.UserID,M.Password, C.ItemName, C.Qty, C.Price From Member M INNER JOIN Cart C on M.UserID =C.UserID";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            GridView1.DataSource = rd;
            GridView1.DataBind();

            rd.Close();
            con.Close();
        }
        public int GetAmount(int qty, int price) {
            return qty * price;
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e) {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e) {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {

        }
    }
}