using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNETIdentityTest {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (User.Identity.IsAuthenticated) {
                    litStatusText.Text = String.Format("안녕하세요,{0}님!!", User.Identity.GetUserName());
                    phStatusText.Visible = true;
                    phLogout.Visible = true;
                }
                else {
                    phLogin.Visible = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            var manager = new UserManager();
            ApplicationUser user = manager.Find(txtUserName.Text, txtPassword.Text);
            if (user!=null) {
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() {
                    IsPersistent = false
                }, identity);
                Response.Redirect("~/Login.aspx");
            }
            else {
                litStatusText.Text = "아이디 또는 암호가 유효하지 않습니다.";
                phStatusText.Visible = true;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e) {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}