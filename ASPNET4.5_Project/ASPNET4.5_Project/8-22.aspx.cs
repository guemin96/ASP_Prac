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
    public partial class _8_22 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindList();
            }
        }

        protected void ListView1_ItemEditing(object sender, ListViewEditEventArgs e) {
            
        }

        protected void ListView1_ItemUpdating(object sender, ListViewUpdateEventArgs e) {

        }

        protected void ListView1_ItemCanceling(object sender, ListViewCancelEventArgs e) {

        }

        protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e) {

        }

        protected void ListView1_SelectedIndexChanging(object sender, ListViewSelectEventArgs e) {

        }

        protected void ListView1_ItemInserting(object sender, ListViewInsertEventArgs e) {

        }
        void BindList() {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            string sql = "SELECT UserID,Password, Name, Phone From Member";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            DataSet ds = new DataSet();
            ad.Fill(ds);

            ListView1.DataSource = ds;
            ListView1.DataBind();
            
            con.Close();
        }
        void UpdateMember(string userID, string password, string name, string phone) {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            string sql = "Update Member Set Password = @Password, Name =@Name, Phone=@Phone Where UserID=@UserID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@UserID", userID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        void DeleteMember(string userID) {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            string sql = "Delete from Member Where UserID=@UserID";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@UserID", userID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}