using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevStateManagement
{
    public partial class FrmStateShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtApplication.Text = Application["Now"].ToString();
            this.txtSession.Text = Session["Now"].ToString();
            if (Cache["Now"] != null)
            {
                this.txtCache.Text = Cache["Now"].ToString();

            }
            if (Request.Cookies["Now"]!= null)
            {
                this.txtCookies.Text = Server.UrlDecode(Request.Cookies["Now"].ToString());
            }
            if (ViewState["Now"] != null)
            {
                this.txtViewState.Text = ViewState["Now"].ToString();

            }
        }
    }
}