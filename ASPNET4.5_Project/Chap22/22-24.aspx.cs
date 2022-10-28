using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Chap22 {
    public partial class _22_24 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            MyDBEntities1 context = new MyDBEntities1();

            StringBuilder sb = new StringBuilder();
            foreach (Member member in context.Members) {
                if (member.Carts.Count()>0) {
                    sb.Append("<b>");
                    sb.Append(member.Name);
                    sb.Append("</b><br/>");
                    foreach (Cart cart in context.Carts) {
                        sb.Append(cart.ItemName);
                        sb.Append(" ");
                        sb.Append(cart.Qty);
                        sb.Append("<br />");
                    }
                    sb.Append("<hr />");
                }
            }
            label1.Text = sb.ToString();
        }
    }
}