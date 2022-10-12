using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Web_Project.Models;
using System.Linq;

namespace Web_Project.Controllers {
    public class ShiftController : Controller {
        [HttpGet]
        public IActionResult Index_test() {
            
            DataSet ds = new DataSet();
            string strConn = "server=192.168.253.14;database=dbMobile;UID=sa;Pwd=gk; Timeout=60";
            List<ShiftTest_Data> SDL = new List<ShiftTest_Data>();

            string TodayDate = DateTime.Now.ToString("yyyyMMdd");

            using (SqlConnection conn = new SqlConnection(strConn)) {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UP_ShiftCheck_Select_Web", conn);
                cmd.CommandTimeout = 3000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = TodayDate;

                DataTable ShiftList = new DataTable();
                ShiftList.TableName = "ShiftList";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ShiftList);


                foreach (DataRow item in ShiftList.Rows) {
                    ShiftTest_Data sd = new ShiftTest_Data();
                    sd.ItemSeq = Int32.Parse(item["ItemSeq"].ToString());
                    sd.Week_Date = item["WeekDate"].ToString();
                    sd.CheckBody = item["CheckBody"].ToString();
                    sd.CheckNM = item["CheckNM"].ToString();
                    sd.Date_Mon = item["Date_Mon"].ToString();
                    sd.Mon_Input_1 = item["Input_1_Mon"].ToString();
                    sd.Mon_Input_2 = item["Input_2_Mon"].ToString();
                    sd.Mon_Input_3 = item["Input_3_Mon"].ToString();

                    sd.Date_Tues = item["Date_Tues"].ToString();
                    sd.Tues_Input_1 = item["Input_1_Tues"].ToString();
                    sd.Tues_Input_2 = item["Input_2_Tues"].ToString();
                    sd.Tues_Input_3 = item["Input_3_Tues"].ToString();
                    
                    sd.Date_Wed = item["Date_Wed"].ToString();
                    sd.Wed_Input_1 = item["Input_1_Wed"].ToString();
                    sd.Wed_Input_2 = item["Input_2_Wed"].ToString();
                    sd.Wed_Input_3 = item["Input_3_Wed"].ToString();
                    
                    sd.Date_Thur = item["Date_Thur"].ToString();
                    sd.Thur_Input_1 = item["Input_1_Thur"].ToString();
                    sd.Thur_Input_2 = item["Input_2_Thur"].ToString();
                    sd.Thur_Input_3 = item["Input_3_Thur"].ToString();
                    
                    sd.Date_Fri = item["Date_Fri"].ToString();
                    sd.Fri_Input_1 = item["Input_1_Fri"].ToString();
                    sd.Fri_Input_2 = item["Input_1_Fri"].ToString();
                    sd.Fri_Input_3 = item["Input_1_Fri"].ToString();

                    sd.Date_Sat = item["Date_Sat"].ToString();
                    sd.Sat_Input_1 = item["Input_1_Sat"].ToString();
                    sd.Sat_Input_2 = item["Input_2_Sat"].ToString();
                    sd.Sat_Input_3 = item["Input_3_Sat"].ToString();


                    SDL.Add(sd);
                }
            }
            return View(SDL);
        }
        [HttpPost]
        public IActionResult Index_test(Date_test dt) {
            DataSet ds = new DataSet();
            string strConn = "server=192.168.253.14;database=dbMobile;UID=sa;Pwd=gk; Timeout=60";
            List<ShiftTest_Data> SDL = new List<ShiftTest_Data>();


            if (!dt.Date.Contains("/")) {
                return View();
            }
            else {
            string DateConvert = DateTime.Parse(dt.Date).ToString("yyyyMMdd");

            using (SqlConnection conn = new SqlConnection(strConn)) {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UP_ShiftCheck_Select_Web", conn);
                cmd.CommandTimeout = 3000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateConvert;

                DataTable ShiftList = new DataTable();
                ShiftList.TableName = "ShiftList";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ShiftList);


                foreach (DataRow item in ShiftList.Rows) {
                    ShiftTest_Data sd = new ShiftTest_Data();
                    sd.ItemSeq = Int32.Parse(item["ItemSeq"].ToString());
                    sd.Week_Date = item["WeekDate"].ToString();
                    sd.CheckBody = item["CheckBody"].ToString();
                    sd.CheckNM = item["CheckNM"].ToString();
                    sd.Date_Mon = item["Date_Mon"].ToString();
                    sd.Mon_Input_1 = item["Input_1_Mon"].ToString();
                    sd.Mon_Input_2 = item["Input_2_Mon"].ToString();
                    sd.Mon_Input_3 = item["Input_3_Mon"].ToString();

                    sd.Date_Tues = item["Date_Tues"].ToString();
                    sd.Tues_Input_1 = item["Input_1_Tues"].ToString();
                    sd.Tues_Input_2 = item["Input_2_Tues"].ToString();
                    sd.Tues_Input_3 = item["Input_3_Tues"].ToString();

                    sd.Date_Wed = item["Date_Wed"].ToString();
                    sd.Wed_Input_1 = item["Input_1_Wed"].ToString();
                    sd.Wed_Input_2 = item["Input_2_Wed"].ToString();
                    sd.Wed_Input_3 = item["Input_3_Wed"].ToString();

                    sd.Date_Thur = item["Date_Thur"].ToString();
                    sd.Thur_Input_1 = item["Input_1_Thur"].ToString();
                    sd.Thur_Input_2 = item["Input_2_Thur"].ToString();
                    sd.Thur_Input_3 = item["Input_3_Thur"].ToString();

                    sd.Date_Fri = item["Date_Fri"].ToString();
                    sd.Fri_Input_1 = item["Input_1_Fri"].ToString();
                    sd.Fri_Input_2 = item["Input_1_Fri"].ToString();
                    sd.Fri_Input_3 = item["Input_1_Fri"].ToString();

                    sd.Date_Sat = item["Date_Sat"].ToString();
                    sd.Sat_Input_1 = item["Input_1_Sat"].ToString();
                    sd.Sat_Input_2 = item["Input_2_Sat"].ToString();
                    sd.Sat_Input_3 = item["Input_3_Sat"].ToString();


                    SDL.Add(sd);
                }
            }
            return View(SDL);
            }
        }

        [HttpGet]
        public IActionResult Index() {

            DataSet ds = new DataSet();
            string strConn = "server=192.168.253.14;database=dbMobile;UID=sa;Pwd=gk; Timeout=60";

            string TodayDate = DateTime.Now.ToString("yyyyMMdd");

            using (SqlConnection conn = new SqlConnection(strConn)) {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UP_ShiftCheck_Select_Web_test", conn);
                cmd.CommandTimeout = 3000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = TodayDate;

                DataSet Ds = new DataSet();
               
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Ds);
                Ds.Tables[0].TableName = "ShiftTemplate";
                Ds.Tables[1].TableName = "ShiftDate";

                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];

                //dt0에 columns 추가해주기

                foreach (DataRow item in dt0.Rows)
                {
                    

                    //이중 foreach문 dt1 Linq 통해서 id값 뽑아내기
                    // dt0.row[item["id"]][]
                    foreach (DataRow item2 in dt1.Rows)
                    {

                    }

                }
                


                DataTable dt = new DataTable();
                dt.Columns.Add("WeekDay");


                dt.Columns.Add("MonDate");
                dt.Columns.Add("Input_1_Mon");
                dt.Columns.Add("Input_2_Mon");
                dt.Columns.Add("Input_3_Mon");
                dt.Columns.Add("ConfirmUser_Mon");

                dt.Columns.Add("TueDate");
                dt.Columns.Add("Input_1_Tue");
                dt.Columns.Add("Input_2_Tue");
                dt.Columns.Add("Input_3_Tue");
                dt.Columns.Add("ConfirmUser_Tue");

                dt.Columns.Add("WedDate");
                dt.Columns.Add("Input_1_Wed");
                dt.Columns.Add("Input_2_Wed");
                dt.Columns.Add("Input_3_Wed");
                dt.Columns.Add("ConfirmUser_Wed");


                dt.Columns.Add("ThrDate");
                dt.Columns.Add("Input_1_Thr");
                dt.Columns.Add("Input_2_Thr");
                dt.Columns.Add("Input_3_Thr");
                dt.Columns.Add("ConfirmUser_Thr");


                dt.Columns.Add("FriDate");
                dt.Columns.Add("Input_1_Fri");
                dt.Columns.Add("Input_2_Fri");
                dt.Columns.Add("Input_3_Fri");
                dt.Columns.Add("ConfirmUser_Fri");

                dt.Columns.Add("SatDate");
                dt.Columns.Add("Input_1_Sat");
                dt.Columns.Add("Input_2_Sat");
                dt.Columns.Add("Input_3_Sat");
                dt.Columns.Add("ConfirmUser_Sat");

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr.ItemArray.Append(item);
                    


                }




                return View();
            }
        }
        [HttpPost]
        public IActionResult Index(Date_test dt) {

            return View();
        }


    }
}
