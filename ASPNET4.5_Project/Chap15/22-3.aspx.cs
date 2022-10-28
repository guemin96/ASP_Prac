using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chap15 {
    public partial class _22_3 : System.Web.UI.Page {
        delegate int PerformCalculation(int x, int y);

        void MyCal(int x, int y, PerformCalculation cal) {
            Response.Write(cal(x, y) + "<br/>");
        }
        int Plus(int x, int y) {
            return x + y;
        }
        int Minus(int x, int y) {
            return x - y;
        }

        protected void Page_Load(object sender, EventArgs e) {
            MyCal(10, 20, Plus);
            MyCal(10, 20, Minus);

        }
    }
}