using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevASPNET {
    public partial class FrmResponseBuffer : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //현재 페이지를 매번 새로 읽어옴
            Response.Expires = -1;
            // 버퍼링 사용
            Response.Buffer = true;
            // 화면 글쓰기
            Response.Write("현재 글은 보여짐<br/>");
            //현재 버퍼에 있는 내용 출력
            Response.Flush();

            //화면에 글쓰기
            Response.Write("현재 글은 안 보임");

            //현재 버퍼 내용 비우기
            Response.Clear();

            // 문자열 출력
            Response.Write("보여짐<br/>");
            Response.End();

            Response.Write("실행 안됨");

        }
    }
}