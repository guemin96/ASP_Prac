using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace DevCounter
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["CurrentVisit"] = 0;
            Application["test1"]="test1";
            Application["test2"]=1;
            Application["test3"]=2;
            Application["test4"]="we";
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["CurrentVisit"] =
                Convert.ToInt32(Application["CurrentVisit"]) + 1;
            Application.UnLock();

        }
        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["CurrentVisit"] =
                Convert.ToInt32(Application["CurrentVisit"]) - 1;
            Application.UnLock();
        }
        protected void Application_End(object sender, EventArgs e)
        {

        }
        protected void Application_Error(object sender, EventArgs e)
        {

        }
    }
}