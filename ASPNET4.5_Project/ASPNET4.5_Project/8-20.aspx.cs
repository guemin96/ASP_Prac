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
    public partial class _8_20 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                BindList();
            }
        }

        protected void DataPager1_PreRender(object sender, EventArgs e) {
            BindList();    
        }

        void BindList() {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
            string sql = "SELECT UserID, Password, Name, Phone From Member";
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            DataSet ds = new DataSet();
            ad.Fill(ds);

            ListView1.DataSource = ds;
            ListView1.DataBind();
        }
    }
}