using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hi.Model {
    public class User {
        /// <summary>
        /// 사용자 번호
        /// </summary>
        public int UserNo { get; set; }
        
        /// <summary>
        /// 사용자 이름
        /// </summary>
        public string UserName { get; set; }
    }
}