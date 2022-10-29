using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BOARD_PROJECT.DotNetNote
{
    public partial class BoardModify : System.Web.UI.Page
    {
        public int BoardId { get; set; } // 게시판 글 번호
        public int Id { get; set; } // 댓글 번호
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["BoardId"] != null && Request.QueryString["Id"] != null)
            {
                BoardId = Convert.ToInt32(Request["BoardId"]);
                Id = Convert.ToInt32(Request["Id"]);
            }
            else
            {
                Response.End();
            }
        }
    }
}