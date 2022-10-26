using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace ASPNETIdentityTest {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e) {
            var manager = new UserManager();
            var user = new ApplicationUser() { UserName = txtUserName.Text };
            IdentityResult result = manager.Create(user, txtPassword.Text);
            if (result.Succeeded) {
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, identity);
                Response.Redirect("~/Login.aspx");
                litStatusMessage.Text = String.Format("{0} 사용자가 생성되었습니다.", user.UserName);
            }
            else {
                litStatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}