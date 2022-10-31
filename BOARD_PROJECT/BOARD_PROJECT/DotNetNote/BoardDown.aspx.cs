using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOARD_PROJECT.DotNetNote.Models;

namespace BOARD_PROJECT.DotNetNote
{
    public partial class BoardDown : System.Web.UI.Page
    {
        private string fileName = " ";
        private string dir = " ";
        private NoteRepository _repository;
        public BoardDown()
        {
            _repository = new NoteRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // 넘어온 번호에 해당하는 파일명 가져오기
            fileName = _repository.GetFileNameById(Convert.ToInt32(Request["Id"]));

            dir = Server.MapPath("./MyFiles");
            if (fileName == null)
            {
                Response.Clear();
                Response.End();
            }
            else
            {
                //다운로드 카운트 증가 메서트 호출
                _repository.UpdateDownCount(fileName);

                // 강제 다운로드 창 띄우기 
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment;filename=Server.UrlPathEncode((fileName.Length>50)?fileName.Substring(fileName.Length - 50,50):fileName");
                Response.WriteFile(dir + fileName);
                Response.End();
            }
        }
    }
}