using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_Validate
{
    public partial class FrmRequiredFieldValidator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.SetFocus(txtUserID);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)//유효성 검사 통과
            {
                Page.ClientScript.RegisterClientScriptBlock(    // ASP.NET cs코드에서 자바스크립트 사용하는 방법
                    this.GetType(),
                    "alertMessage",
                    "<script>alert('통과');</script>");
            }
        }
    }
}