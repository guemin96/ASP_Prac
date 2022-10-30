using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace BOARD_PROJECT.DotNetNote.Models
{
    public class NoteCommentRepository
    {
        private SqlConnection con;

        public NoteCommentRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        /// <summary>
        /// 특정 게시물에 댓글 추가
        /// </summary>
        /// <param name="model"></param>
        public void AddNoteComment(NoteComment model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@BoardId", value: model.BoardId, dbType: DbType.Int32);
            parameters.Add("@Name", value: model.Name, dbType: DbType.String);
            parameters.Add("@Opinion", value: model.Opinion, dbType: DbType.String);
            parameters.Add("@Password", value: model.Password, dbType: DbType.String);

            string sql = @"Insert Into NoteComments (BoardId, Name, Opinion, Password)
                            Values(@BoardId,@Name,@Opinion,@Password);
                            Update Notes Set CommentCount = CommentCount + 1
                            Where Id = @BoardId";

            con.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
        }
        /// <summary>
        /// 특정 게시물의 특정 Id에 해당하는 댓글 카운트
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int GetCountBy (int boardId, int id, string password)
        {
            return con.Query<int>("@ Select Count(*) From NoteComments" +
                                    "Where BoardId = @BoardId And Id = @Id And Password = @Password",
                                    new { BoardId = boardId, Id = id, Password = password },
                                    commandType: CommandType.Text).SingleOrDefault();
        }
        /// <summary>
        /// 최근 댓글 리스트 전체
        /// </summary>
        /// <returns></returns>
        public List<NoteComment> GetRecentComments()
        {
            string sql = @"Select Top 3 Id, BoardId, Opinion, PostDate, From NoteComments Order By Id Desc";
            return con.Query<NoteComment>(sql, commandType: CommandType.Text).ToList();
        }

    }
}