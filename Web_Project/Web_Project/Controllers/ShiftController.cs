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
        public IActionResult Index(string date) {

            string strConn = "server=192.168.253.14;database=dbMobile;UID=sa;Pwd=gk; Timeout=60";
            string SelectDT = null;
            if (date== null) {
                SelectDT = DateTime.Now.ToString("yyyyMMdd");
            }
            else {
                SelectDT= DateTime.Parse(date).ToString("yyyyMMdd");
            }

            List<ShiftCheckTotalMember> SCTM = new List<ShiftCheckTotalMember>();


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

                // 템플릿
                DataTable dtTemplate = Ds.Tables[0];
                // 실데이터
                DataTable dtRealData = Ds.Tables[1];
                // 날짜데이터
                DataTable dtDate = Ds.Tables[2];

                ViewBag.dtTemp = dtTemplate;
                ViewBag.dtReal = dtRealData;
                ViewBag.dtDate = dtDate;
                    
                    
                return View();
            }
        }






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
                    sd.Tue_Input_1 = item["Input_1_Tues"].ToString();
                    sd.Tue_Input_2 = item["Input_2_Tues"].ToString();
                    sd.Tue_Input_3 = item["Input_3_Tues"].ToString();
                    
                    sd.Date_Wed = item["Date_Wed"].ToString();
                    sd.Wed_Input_1 = item["Input_1_Wed"].ToString();
                    sd.Wed_Input_2 = item["Input_2_Wed"].ToString();
                    sd.Wed_Input_3 = item["Input_3_Wed"].ToString();
                    
                    sd.Date_Thur = item["Date_Thur"].ToString();
                    sd.Thr_Input_1 = item["Input_1_Thur"].ToString();
                    sd.Thr_Input_2 = item["Input_2_Thur"].ToString();
                    sd.Thr_Input_3 = item["Input_3_Thur"].ToString();
                    
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
        public IActionResult Index_test(SelectDate dt) {
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
                    sd.Tue_Input_1 = item["Input_1_Tues"].ToString();
                    sd.Tue_Input_2 = item["Input_2_Tues"].ToString();
                    sd.Tue_Input_3 = item["Input_3_Tues"].ToString();

                    sd.Date_Wed = item["Date_Wed"].ToString();
                    sd.Wed_Input_1 = item["Input_1_Wed"].ToString();
                    sd.Wed_Input_2 = item["Input_2_Wed"].ToString();
                    sd.Wed_Input_3 = item["Input_3_Wed"].ToString();

                    sd.Date_Thur = item["Date_Thur"].ToString();
                    sd.Thr_Input_1 = item["Input_1_Thur"].ToString();
                    sd.Thr_Input_2 = item["Input_2_Thur"].ToString();
                    sd.Thr_Input_3 = item["Input_3_Thur"].ToString();

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

        public void DataList(DataTable dt0, DataTable dt1) {
            foreach (DataRow item in dt0.Rows) {
                int num = Int32.Parse(item[1].ToString());
                DataTable data_Detail = dt1.Select($"ItemSeq='{num}'").CopyToDataTable();

                DataRow[] drs = dt1.Select($"ItemSeq='{num}'");

                //이중 foreach문 dt1 Linq 통해서 id값 뽑아내기
                // dt0.row[item["id"]][]
                foreach (DataRow item2 in data_Detail.Rows) {
                    if (item2[2].ToString() == "월") {

                        //dt0.Rows[num - 1]["Date_Mon"] = item2[1].ToString();
                        dt0.Rows[num - 1]["Mon_Input_1"] = item2[5].ToString();
                        dt0.Rows[num - 1]["Mon_Input_2"] = item2[6].ToString();
                        dt0.Rows[num - 1]["Mon_Input_3"] = item2[7].ToString();
                        dt0.Rows[num - 1]["Mon_ConfirmUser"] = item2[8].ToString();
                    }
                    else if (item2[2].ToString() == "화") {
                        //dt0.Rows[num - 1]["Date_Tue"] = item2[1].ToString();
                        dt0.Rows[num - 1]["Tue_Input_1"] = item2[5].ToString();
                        dt0.Rows[num - 1]["Tue_Input_2"] = item2[6].ToString();
                        dt0.Rows[num - 1]["Tue_Input_3"] = item2[7].ToString();
                        dt0.Rows[num - 1]["Tue_ConfirmUser"] = item2[8].ToString();
                    }
                    else if (item2[2].ToString() == "수") {
                        //dt0.Rows[num - 1]["Date_Wed"] = item2[1].ToString();
                        dt0.Rows[num - 1]["Wed_Input_1"] = item2[5].ToString();
                        dt0.Rows[num - 1]["Wed_Input_2"] = item2[6].ToString();
                        dt0.Rows[num - 1]["Wed_Input_3"] = item2[7].ToString();
                        dt0.Rows[num - 1]["Wed_ConfirmUser"] = item2[8].ToString();
                    }
                    else if (item2[2].ToString() == "목") {
                        //dt0.Rows[num - 1]["Date_Thr"] = item2[1].ToString();
                        dt0.Rows[num - 1]["Thr_Input_1"] = item2[5].ToString();
                        dt0.Rows[num - 1]["Thr_Input_2"] = item2[6].ToString();
                        dt0.Rows[num - 1]["Thr_Input_3"] = item2[7].ToString();
                        dt0.Rows[num - 1]["Thr_ConfirmUser"] = item2[8].ToString();
                    }
                    else if (item2[2].ToString() == "금") {
                        //dt0.Rows[num - 1]["Date_Fri"] = item2[1].ToString();
                        dt0.Rows[num - 1]["Fri_Input_1"] = item2[5].ToString();
                        dt0.Rows[num - 1]["Fri_Input_2"] = item2[6].ToString();
                        dt0.Rows[num - 1]["Fri_Input_3"] = item2[7].ToString();
                        dt0.Rows[num - 1]["Fri_ConfirmUser"] = item2[8].ToString();
                    }
                    else if (item2[2].ToString() == "토") {
                        //dt0.Rows[num - 1]["Date_Sat"] = item2[1].ToString();
                        dt0.Rows[num - 1]["Sat_Input_1"] = item2[5].ToString();
                        dt0.Rows[num - 1]["Sat_Input_2"] = item2[6].ToString();
                        dt0.Rows[num - 1]["Sat_Input_3"] = item2[7].ToString();
                        dt0.Rows[num - 1]["Sat_ConfirmUser"] = item2[8].ToString();
                    }
                }
            }
        }
        public void DataList2(List<ShiftCheckTotalMember> SCTM, DataTable dt0) {
            foreach (DataRow item in dt0.Rows) {
                ShiftCheckTotalMember STM = new ShiftCheckTotalMember();
                STM.TemplateID = Int32.Parse(item["TemplateID"].ToString());
                STM.ItemSeq = Int32.Parse(item["ItemSeq"].ToString());
                STM.RoomID = Int32.Parse(item["RoomID"].ToString());
                STM.CheckTypeID = Int32.Parse(item["CheckTypeID"].ToString());
                STM.CheckNM = item["CheckNM"].ToString();
                STM.CheckBody = item["CheckBody"].ToString();
                STM.OrderBy = Int32.Parse(item["OrderBy"].ToString());
                STM.UseYN = item["UseYN"].ToString();
                STM.Date_Mon = item["Date_Mon"].ToString();
                STM.Mon_Input_1 = item["Mon_Input_1"].ToString();
                STM.Mon_Input_2 = item["Mon_Input_2"].ToString();
                STM.Mon_Input_3 = item["Mon_Input_3"].ToString();
                STM.Mon_ConfirmUser = item["Mon_ConfirmUser"].ToString();

                STM.Date_Tue = item["Date_Tue"].ToString();
                STM.Tue_Input_1 = item["Tue_Input_1"].ToString();
                STM.Tue_Input_2 = item["Tue_Input_2"].ToString();
                STM.Tue_Input_3 = item["Tue_Input_3"].ToString();
                STM.Tue_ConfirmUser = item["Tue_ConfirmUser"].ToString();


                STM.Date_Wed = item["Date_Wed"].ToString();
                STM.Wed_Input_1 = item["Wed_Input_1"].ToString();
                STM.Wed_Input_2 = item["Wed_Input_2"].ToString();
                STM.Wed_Input_3 = item["Wed_Input_3"].ToString();
                STM.Wed_ConfirmUser = item["Wed_ConfirmUser"].ToString();

                STM.Date_Thr = item["Date_Thr"].ToString();
                STM.Thr_Input_1 = item["Thr_Input_1"].ToString();
                STM.Thr_Input_2 = item["Thr_Input_2"].ToString();
                STM.Thr_Input_3 = item["Thr_Input_3"].ToString();
                STM.Thr_ConfirmUser = item["Thr_ConfirmUser"].ToString();


                STM.Date_Fri = item["Date_Fri"].ToString();
                STM.Fri_Input_1 = item["Fri_Input_1"].ToString();
                STM.Fri_Input_2 = item["Fri_Input_2"].ToString();
                STM.Fri_Input_3 = item["Fri_Input_3"].ToString();
                STM.Fri_ConfirmUser = item["Fri_ConfirmUser"].ToString();


                STM.Date_Sat = item["Date_Sat"].ToString();
                STM.Sat_Input_1 = item["Sat_Input_1"].ToString();
                STM.Sat_Input_2 = item["Sat_Input_2"].ToString();
                STM.Sat_Input_3 = item["Sat_Input_3"].ToString();
                STM.Sat_ConfirmUser = item["Sat_ConfirmUser"].ToString();


                SCTM.Add(STM);

            }
        }
        [HttpGet]
        public IActionResult Index_test2(string searchDate) {

            string strConn = "server=192.168.253.14;database=dbMobile;UID=sa;Pwd=gk; Timeout=60";

            string TodayDate = DateTime.Now.ToString("yyyyMMdd");

            List<ShiftCheckTotalMember> SCTM = new List<ShiftCheckTotalMember>();


            using (SqlConnection conn = new SqlConnection(strConn)) {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UP_ShiftCheck_Select_Web_test2", conn);
                cmd.CommandTimeout = 3000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = TodayDate;

                DataSet Ds = new DataSet();
               
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Ds);
                Ds.Tables[0].TableName = "ShiftTemplate";
                Ds.Tables[1].TableName = "ShiftDate";

                // 템플릿
                DataTable dtTemplate = Ds.Tables[0];
                // 실데이터
                DataTable dtRealData = Ds.Tables[1];
                
                DataList(dtTemplate, dtRealData);
                DataList2(SCTM, dtTemplate);
                return View(SCTM);
            }
        }
        [HttpPost]
        public IActionResult Index_test2(SelectDate SD) {

            string strConn = "server=192.168.253.14;database=dbMobile;UID=sa;Pwd=gk; Timeout=60";

            string DateConvert = DateTime.Parse(SD.Date).ToString("yyyyMMdd");

            List<ShiftCheckTotalMember> SCTM = new List<ShiftCheckTotalMember>();


            using (SqlConnection conn = new SqlConnection(strConn)) {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UP_ShiftCheck_Select_Web_test2", conn);
                cmd.CommandTimeout = 3000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = DateConvert;

                DataSet Ds = new DataSet();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Ds);
                Ds.Tables[0].TableName = "ShiftTemplate";
                Ds.Tables[1].TableName = "ShiftDate";

                DataTable dtTemplate = Ds.Tables[0];
                DataTable dtRealData = Ds.Tables[1];

                DataList(dtTemplate, dtRealData);
                DataList2(SCTM, dtTemplate);
                return View(SCTM);
            }
        }
    }
}
