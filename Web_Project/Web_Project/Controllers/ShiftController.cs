using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Web_Project.Models;
using System.Linq;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Html;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace Web_Project.Controllers {
    public class ShiftController : Controller {

        [HttpGet]
        public IActionResult Index(string date) {

            string strConn = "server=192.168.253.14;database=dbMobile;UID=sa;Pwd=gk; Timeout=60";
            string today = DateTime.Now.ToString("yyyyMMdd");
            string SelectDT = null;
            if (date == null) {
                SelectDT = today;
            }
            else {
                DateTime dt;
                if (DateTime.TryParse(date,out dt)) {
                    SelectDT = DateTime.Parse(date).ToString("yyyyMMdd");
                }
                else {
                    SelectDT = today;
                }
            }
            //string date = DateTime.Now.ToString("yyyy-MM-dd");
            //SelectDT = DateTime.Now.ToString("yyyyMMdd");

            using (SqlConnection conn = new SqlConnection(strConn)) {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UP_ShiftCheck_Select_Web", conn);
                cmd.CommandTimeout = 3000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = SelectDT;

                DataSet Ds = new DataSet();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Ds);
                Ds.Tables[0].TableName = "ShiftTemplate";
                Ds.Tables[1].TableName = "ShiftDate";
                Ds.Tables[2].TableName = "DateData";

                if (date == null) {
                    ViewBag.Date = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else {
                    date = DateTime.ParseExact(SelectDT, "yyyyMMdd", null).ToString("yyyy-MM-dd");

                    ViewBag.Date = date;

                }
                return View(Ds);
            }
        }
                
        public IActionResult Test() {
            return View();
        }
    }
}
