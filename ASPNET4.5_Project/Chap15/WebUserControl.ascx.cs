﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chap15 {
    public partial class WebUserControl : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            Label1.Text = DateTime.Now.ToLongTimeString();
        }
    }
}