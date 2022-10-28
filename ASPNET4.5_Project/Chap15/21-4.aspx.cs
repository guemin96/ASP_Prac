using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chap15 {
    public partial class _21_4 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            DataSet myDataSet = (DataSet)Cache["MyDataSet"];
            if (myDataSet == null) {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Select * from Member", con);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds);

                Cache["MyDataSet"] = ds;
                myDataSet = ds;
                Label1.Text = "데이터 캐시 새로 생성";
            }
            else {
                Label1.Text = "데이터 캐시 사용";
            }
            GridView1.DataSource = myDataSet;
            GridView1.DataBind();
        }
    }
}