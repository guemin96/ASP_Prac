using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chap22 {
    public partial class _22_27 : System.Web.UI.Page {
        
        protected void Page_Load(object sender, EventArgs e) {
            MyDBEntities1 context = new MyDBEntities1();

            ObjectResult<usp_SelectMemberByUserID_Result> results = context.usp_SelectMemberByUserID("1");
            usp_SelectMemberByUserID_Result result = results.Single();
            Response.Write(result.UserID + " " + result.Name + " " + result.Password + " " + result.Phone);
            //ObjectResult<usp_SelectMember_Result> results = context.usp_SelectMember();

            //foreach (var item in results) {
            //    Response.Write(item.UserID + " " + item.Name + " " + item.Password + " " + item.Phone);
            //}
        }
    }
}