using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOARD_PROJECT.DotNetNote.Models
{
    /// <summary>
    /// 게시판의 글 내용(Content)의 인코딩 처리 방식
    /// </summary>
    public enum ContentEncodingType
    {
        Text,
        Html,
        Mixed
    }
}