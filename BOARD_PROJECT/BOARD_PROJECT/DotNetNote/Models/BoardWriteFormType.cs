using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOARD_PROJECT.DotNetNote.Models
{
    /// <summary>
    /// 게시판의 글쓰기 폼 구성 분류(Write, Modify, Reply)
    /// </summary>
    public enum BoardWriteFormType
    {
        Write,
        Modify,
        Reply
    }
}