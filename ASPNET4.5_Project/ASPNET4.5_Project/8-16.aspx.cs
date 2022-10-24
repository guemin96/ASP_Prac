using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNET4._5_Project {
    public partial class _8_16 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindList();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e) {
            GridView1.EditIndex = e.NewEditIndex;
            BindList();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            string userID = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string password = e.NewValues["Password"].ToString();
            string name = e.NewValues["Name"].ToString();
            string phone = e.NewValues["Phone"].ToString();

            UpdateMember(userID, password, name, phone);
            GridView1.EditIndex = -1;
            BindList();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            GridView1.EditIndex = -1;
            BindList();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            string userID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            DeleteMember(userID);
            BindList();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e) {
            Label1.Text = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
        }
        void BindList() {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            string sql = "SELECT UserID,Password, Name, Phone From Member";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            SqlDataReader rd = cmd.ExecuteReader();

            GridView1.DataSource = rd;
            GridView1.DataBind();

            rd.Close();
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