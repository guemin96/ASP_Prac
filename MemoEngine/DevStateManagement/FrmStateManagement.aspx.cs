using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevStateManagement
{
    public partial class FrmStateManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtApplication.Text = Application["Now"].ToString();
                this.txtSession.Text = Session["Now"].ToString();

                if (Cache["Now"] != null)
                {
                    this.txtCache.Text = Cache["Now"].ToString();
                }
                if (Request.Cookies["Now"] != null)
                {
                    this.txtCookies.Text = Server.UrlDecode(Request.Cookies["Now"].ToString());
                }
                if (ViewState["Now"] != null)
                {
                    this.txtViewState.Text = ViewState["Now"].ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Application["Now"] = this.txtApplication.Text;
            Session["Now"] = this.txtSession.Text;
            Cache["Now"] = this.txtCache.Text;
            Response.Cookies["Now"].Value = Server.UrlEncode(txtCookies.ToString());
            ViewState["Now"] = this.txtViewState.Text;
            Response.Redirect("FrmStateShow.aspx");
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {

        }
    }
}