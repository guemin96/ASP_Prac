using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Web_Project.Models;

namespace Web_Project.Controllers {
    public class ShiftController : Controller {
        public IActionResult Index() {
            
            DataSet ds = new DataSet();
            string strConn = "server=192.168.253.14;database=dbMobile;UID=sa;Pwd=gk; Timeout=60";
            List<ShiftTest_Data> SDL = new List<ShiftTest_Data>();

            using (SqlConnection conn = new SqlConnection(strConn)) {
                if (conn.State == ConnectionState.Closed) {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("UP_ShiftCheck_Select_Web", conn);
                cmd.CommandTimeout = 3000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SelectDate", SqlDbType.VarChar).Value = "20221011";

                DataTable ShiftList = new DataTable();
                ShiftList.TableName = "ShiftList";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ShiftList);


                foreach (DataRow item in ShiftList.Rows) {
                    ShiftTest_Data sd = new ShiftTest_Data();
                    sd.ItemSeq = Int32.Parse(item[0].ToString());
                    sd.CheckBody = item[1].ToString();
                    sd.CheckNM = item[2].ToString();
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
}
