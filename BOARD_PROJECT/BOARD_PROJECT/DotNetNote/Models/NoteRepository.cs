using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using System.Linq;

namespace BOARD_PROJECT.DotNetNote.Models
{
    public class NoteRepository
    {
        private SqlConnection con;

        public NoteRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        /// <summary>
        /// 데이터 저장, 수정, 답변 공통 메서드
        /// </summary>
        /// <param name="n"></param>
        /// <param name="formType"></param>
        /// <returns></returns>
        public int SaveOrUpdate(Note n, BoardWriteFormType formType)
        {
            int r = 0;

            var p = new DynamicParameters();

            p.Add("@Name",value: n.Name, dbType: DbType.Int32);
            p.Add("@Email",value: n.Email, dbType: DbType.String);
            p.Add("@Title",value: n.Title, dbType: DbType.String);
            p.Add("@Content",value: n.Content, dbType: DbType.String);
            p.Add("@Password",value: n.Password, dbType: DbType.String);
            p.Add("@Encoding",value: n.Encoding, dbType: DbType.String);
            p.Add("@Homepage",value: n.Homepage, dbType: DbType.String);
            p.Add("@FileName",value: n.FileName, dbType: DbType.String);
            p.Add("@FileSize",value: n.FileSize, dbType: DbType.Int32);

            switch (formType)
            {
                case BoardWriteFormType.Write:
                    //글쓰기
                    p.Add("@PostIp", value: n.PostIp, dbType: DbType.String);

                    r = con.Execute("WriteNote", p, commandType: CommandType.StoredProcedure);
                    break;
                case BoardWriteFormType.Modify:
                    //글 수정하기
                    p.Add("@ModifyIp", value: n.ModifyIp, dbType: DbType.String);
                    p.Add("@Id", value: n.Id, dbType: DbType.Int32);

                    r = con.Execute("ModifyNote", p, commandType: CommandType.StoredProcedure);
                    break;
                case BoardWriteFormType.Reply:
                    p.Add("@PostIp", value: n.PostIp, dbType: DbType.String);
                    p.Add("@ParentNum", value: n.ParentNum, dbType: DbType.Int32);

                    r = con.Execute("ReplyNote", p, commandType: CommandType.StoredProcedure);
                    break;
                default:
                    break;
            }
            return r;
        }
        /// <summary>
        /// 게시판 글쓰기
        /// </summary>
        /// <param name="vm"></param>
        public void Add(Note vm)
        {
            try
            {
                SaveOrUpdate(vm, BoardWriteFormType.Write);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 게시판 글 수정하기
        /// </summary>
        /// <param name="vm"></param>
        public int UpdateNote(Note vm)
        {
            int r = 0;
            try
            {
                r= SaveOrUpdate(vm, BoardWriteFormType.Modify);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            return r;
        }
        /// <summary>
        /// 답변 글쓰기
        /// </summary>
        /// <param name="vm"></param>
        public void ReplyNote(Note vm)
        {
            try
            {
                SaveOrUpdate(vm, BoardWriteFormType.Reply);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 게시판 리스트
        /// </summary>
        /// <returns>페이지 번호</returns>
        public List<Note> GetAll(int page)
        {
            try
            {
                var parameters = new DynamicParameters(new { Page = page });
                return con.Query<Note>("ListNotes", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        public int GetCountBySearch(string searchField, string searchQuery)
        {
            try
            {
                return con.Query<int>("SearchNoteCount", new
                {
                    searchField = searchField,
                    searchQuery = searchQuery
                },
                commandType:CommandType.StoredProcedure

                ).SingleOrDefault();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public int GetCountAll()
        {
            try
            {
                return con.Query<int>("Select Count(*) From Notes").SingleOrDefault();
            }
            catch (System.Exception)
            {
                return -1;
            }
        }
        /// <summary>
        /// Id에 해당하는 파일명 변환
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetFileNameById(int id)
        {
            return con.Query<string>("Select FileName From Notes where Id =@Id", new {Id=id}).SingleOrDefault();
        }
        /// <summary>
        /// 검색 결과 리스트
        /// </summary>
        /// <param name="page"></param>
        /// <param name="searchField"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public List<Note> GetSearchAll( int page, string searchField, string searchQuery)
        {
            var parameters = new DynamicParameters(new
            {
                Page = page,
                searchField= searchField,
                SearchQuery = searchQuery
            });
            return con.Query<Note>("SearchNotes", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
        /// <summary>
        /// 다운 카운트 1 증가
        /// </summary>
        public void UpdateDownCount(string fileName)
        {
            con.Execute("Update Notes Set DownCount = DownCount + 1 Where FileName = @FileName", new { FileName = fileName });
        }
        public void UpdateDownCountById(int id)
        {
            var p = new DynamicParameters(new { Id = id });
            con.Execute("Update Notes Set DownCount + 1 Where Id =@id",p,commandType:CommandType.Text);
        }
        /// <summary>
        /// 상세보기
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Note GetNoteById(int id)
        {
            var parameters = new DynamicParameters(new { Id = id });
            return con.Query<Note>("ViewNote",parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();  
        }
        public int DeleteNote(int id, string password)
        {
            return con.Execute("DeleteNote", new { Id = id, Password = password }, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 최근 올라온 사진 리스트 4개 출력
        /// </summary>
        public List<Note> GetNewPhotos()
        {
            string sql =
                "SELECT TOP 4 Id, Title, FileName, FileSize FROM Notes "
                + " Where FileName Like '%.png' Or FileName Like '%.jpg' Or "
                + " FileName Like '%.jpeg' Or FileName Like '%.gif' "
                + " Order By Id Desc";
            return con.Query<Note>(sql).ToList();
        }

        /// <summary>
        /// 최근 글 리스트
        /// </summary>
        public List<Note> GetNoteSummaryByCategory(string category)
        {
            string sql = "SELECT TOP 3 Id, Title, Name, PostDate, FileName, "
                + " FileSize, ReadCount, CommentCount, Step "
                + " FROM Notes "
                + " Where Category = @Category Order By Id Desc";
            return con.Query<Note>(sql, new { Category = category }).ToList();
        }

        /// <summary>
        /// 최근 글 리스트 전체(최근 글 5개 리스트)
        /// </summary>
        public List<Note> GetRecentPosts()
        {
            string sql = "SELECT TOP 3 Id, Title, Name, PostDate FROM Notes "
                + " Order By Id Desc";
            return con.Query<Note>(sql).ToList();
        }

        /// <summary>
        /// 최근 글 리스트 n개
        /// </summary>
        public List<Note> GetRecentPosts(int numberOfNotes)
        {
            string sql =
                $"SELECT TOP {numberOfNotes} Id, Title, Name, PostDate "
                + " FROM Notes Order By Id Desc";
            return con.Query<Note>(sql).ToList();
        }

    }
}