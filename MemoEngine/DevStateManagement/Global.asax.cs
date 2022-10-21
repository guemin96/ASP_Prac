using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace DevStateManagement
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["Now"] = DateTime.Now;
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Now"] = DateTime.Now;
        }
        protected void Session_End(object sender, EventArgs e)
        {

        }
        protected void Application_End(object sender, EventArgs e)
        {

        }
        protected void Application_Error(object sender, EventArgs e)
        {

        }
    }
}