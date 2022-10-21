using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevASPNET {
    public partial class FrmApplicationSession : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Application["Count"]==null) {
                Application.Lock();//먼저 온 사용자가 변수 수정 잠그기
                Application["Count"] = 1; //응용 프로그램 변수 선언 및 초기화
                Application.UnLock();//잠금 해제 : 다른 사용자가 사용 가능
            }
            else {
                Application["Count"]=(int)Application["Count"]+1;
            }
            if (Session["Count"]==null) {
                Session["Count"] = 1;
            }
            else {
                Session["Count"]=(int)Session["Count"]+1;
            }
            this.lblApplication.Text = Application["Count"].ToString();
            this.lblSession.Text = Session["Count"].ToString();
            this.lblSessionID.Text = Session.SessionID;
            this.lblTimeout.Text = Session.Timeout.ToString();
        }
    }
}