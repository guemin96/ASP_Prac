using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevASPNET {
    public partial class FrmRequest : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string strUserId = " ";
            string strPassword = string.Empty;
            string strName = " ";
            string strAge = string.Empty;

            strUserId = Request.QueryString["UserID"];
            strPassword = Request.Params["Password"];
            strName = Request.Form["Name"];
            strAge = Request["Age"];

            string strMsg = String.Format(
              "입력하신 아이디는 {0}이고 "
              +"암호는 {1}이고 "
              +"이름은 {2}이고 "
              + "나이는{3}살입니다. ",
              strUserId, strPassword,
              strName, strAge);

            Response.Write(strMsg);

        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            string name = Name.Text;
            int age = Convert.ToInt32(Age.Text);
        }
    }
}