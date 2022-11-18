using BOARD_ASP_CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace BOARD_ASP_CORE.Controllers {
    public class BoardController : Controller {
        string conquery = "Data Source=localhost;Initial Catalog=DotNetNote;User ID=sa;Password=1234";
        public IActionResult Index() {
            return View();
        }
        public IActionResult BoardList(int page) {

            page = page.ToString() == "0" ? 1: page;
            int totalCount = 0;
            DataSet ds = new DataSet();


            using (SqlConnection con = new SqlConnection(conquery)) {
                if (con.State == System.Data.ConnectionState.Closed) {
                    con.Open();
                }
                string query = "select count(*) from TB_Notes";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                totalCount = Convert.ToInt32(cmd.ExecuteScalar()); 
                con.Close();
            }
            int countList = 10;

            int totalPage = totalCount / countList;
            if (totalCount % countList > 0) {
                totalPage++;
            }
            if (totalPage < page) {
                page = totalPage;
            }
            
            int countPage = 10;

            int startPage = ((page - 1) / countPage) * countPage + 1;
            int endPage = startPage + countPage - 1;
            if (totalPage < endPage) {
                endPage = totalPage;    
            }
            int startCount = ((page - 1) * countPage) + 1;
            int EndCount = startCount + 9;

            ViewBag.StartPage = startPage;
            ViewBag.EndPage = endPage;
            ViewBag.Page = page;
            ViewBag.TotalPage = totalPage;


            using (SqlConnection con = new SqlConnection(conquery)) {
                if (con.State == System.Data.ConnectionState.Closed) {
                    con.Open();
                }
                //string query = "Select * from Notes";
                SqlCommand cmd = new SqlCommand("NEW_PagingNote",con);
                cmd.Parameters.Add("@IStartCount",SqlDbType.Int).Value = startCount;
                cmd.Parameters.Add("@IEndCount", SqlDbType.Int).Value= EndCount;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ds.Tables.Add(dt);
                con.Close();
            }

            return View(ds);
        }
        [HttpGet]
        public IActionResult CreateBoard() {

            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY")==null) {
                return RedirectToAction("Login", "Home");
            }
            else {
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateBoard(NoteM model) {
            if (ModelState.IsValid) {

                DateTime nowDate = DateTime.Now.Date;

                //string conquery = "Data Source=localhost;Initial Catalog=DotNetNote;User ID=sa;Password=1234";
                using (SqlConnection con = new SqlConnection(conquery)) {
                    if (con.State == System.Data.ConnectionState.Closed) {
                        con.Open();
                    }
                    string conquery = "insert into TB_Notes (UserId,Name,Title,PostDate,Content,ReadCount) values (@IUserId,@vcName,@vcTitle,@dtPostDate,@txContent,@iReadCount)";
                    SqlCommand cmd = new SqlCommand(conquery, con);
                    cmd.Parameters.Add("@IUserId", SqlDbType.Int).Value = HttpContext.Session.GetInt32("USER_LOGIN_KEY").Value;
                    cmd.Parameters.Add("@vcName", SqlDbType.NVarChar).Value = model.Name;
                    cmd.Parameters.Add("@vcTitle", SqlDbType.NVarChar).Value = model.Title;
                    cmd.Parameters.Add("@dtPostDate", SqlDbType.DateTime).Value = nowDate;
                    cmd.Parameters.Add("@txContent", SqlDbType.Text).Value = model.Content;
                    cmd.Parameters.Add("@iReadCount", SqlDbType.Int).Value = 0;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            return RedirectToAction("BoardList", "Board");
        }
        public IActionResult BoardDetail(int num) {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conquery)) {
                if (con.State == ConnectionState.Closed) {
                    con.Open();
                }
                string query = $"Update TB_Notes set ReadCount=ReadCount+1 where Id = {num}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            using (SqlConnection con = new SqlConnection(conquery)) {
                if (con.State == ConnectionState.Closed) {
                    con.Open();
                }
                string query = $"Select * from TB_Notes where Id={num}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                con.Close();
            }

            return View(dt);
        }
        [HttpGet]
        public IActionResult UpdateBoard(int num) {

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conquery)) {
                if (con.State == System.Data.ConnectionState.Closed) {
                    con.Open();
                }
                string query = $"Select * from TB_Notes where Id={num}";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                con.Close();
            }

            return View(dt);

        }
        [HttpPost]
        public IActionResult UpdateBoard(NoteM model) {
            if (ModelState.IsValid) {

                DateTime nowDate = DateTime.Now.Date;

                //string conquery = "Data Source=localhost;Initial Catalog=DotNetNote;User ID=sa;Password=1234";
                using (SqlConnection con = new SqlConnection(conquery)) {
                    if (con.State == ConnectionState.Closed) {
                        con.Open();
                    }
                    string conquery = "Update TB_Notes set Name = @vcName, Title = @vcTitle, PostDate = @dtPostDate, Content = @txContent where Id=@IId";
                    SqlCommand cmd = new SqlCommand(conquery, con);
                    cmd.Parameters.Add("@IId", SqlDbType.Int).Value = model.Id;
                    cmd.Parameters.Add("@vcName", SqlDbType.NVarChar).Value = model.Name;
                    cmd.Parameters.Add("@vcTitle", SqlDbType.NVarChar).Value = model.Title;
                    cmd.Parameters.Add("@dtPostDate", SqlDbType.DateTime).Value = nowDate;
                    cmd.Parameters.Add("@txContent", SqlDbType.Text).Value = model.Content;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            return RedirectToAction("BoardList", "Board");

        }
        public IActionResult DeleteBoard(int num) {

            using (SqlConnection con = new SqlConnection(conquery)) {
                if (con.State == ConnectionState.Closed) {
                    con.Open();
                }
                string conquery = $"delete from TB_Notes where Id = {num}";
                SqlCommand cmd = new SqlCommand(conquery, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();

            }

            return RedirectToAction("BoardList", "Board");
        }
    }
}
