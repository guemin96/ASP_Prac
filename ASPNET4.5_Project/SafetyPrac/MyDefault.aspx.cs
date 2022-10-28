using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SafetyPrac {
    public partial class MyDefault : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Label1.Text = Page.User.Identity.Name + "님 환영합니다.";
        }

        protected void Button1_Click(object sender, EventArgs e) {
            FormsAuthentication.SignOut();
            Response.Redirect(FormsAuthentication.LoginUrl);
        }
    }
}