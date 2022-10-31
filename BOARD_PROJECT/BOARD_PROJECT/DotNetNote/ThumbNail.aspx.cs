﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace BOARD_PROJECT.DotNetNote
{
    public partial class ThumbNail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int boxWidth = 100;
            int boxHeight = 100;
            double scale = 0;

            //파일 이름 설정
            string fileName = String.Empty;
            string selectedFile = String.Empty;

            if (Request["FileName"]!= null)
            {
                selectedFile = Request.QueryString["FileName"];
                fileName = Server.MapPath("./MyFiles/" + selectedFile);
            }
            else
            {
                selectedFile = "./images/dnn/img.jpg";
                fileName = Server.MapPath("/images/dnn/img.jpg");
            }

            int tmpW = 0;
            int tmpH = 0;

            if (Request.QueryString["Width"]!= null && Request.QueryString["Height"]!= null)
            {
                tmpW = Convert.ToInt32(Request.QueryString["Width"]); 
                tmpH = Convert.ToInt32(Request.QueryString["Height"]);
            }
            if (tmpW>0 && tmpH>0)
            {
                boxWidth = tmpW;
                boxHeight = tmpH;
            }

            Bitmap b = new Bitmap(fileName);

            //크기 비율을 계산한다.
            if (b.Height<b.Width)
            {
                scale = ((double)boxHeight) / b.Width;

            }
            else
            {
                scale = ((double)boxWidth) / b.Height;
            }

            int newWidth = (int)(scale * b.Width);
            int newHeight = (int)(scale * b.Height);

            Bitmap bOut = new Bitmap(b, newWidth, newHeight);
            bOut.Save(Response.OutputStream, b.RawFormat);

            //마무리
            b.Dispose();
            bOut.Dispose();
        }
    }
}