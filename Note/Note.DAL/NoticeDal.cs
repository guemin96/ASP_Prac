using Microsoft.Extensions.Configuration;
using Note.DAL.DataContext;
using Note.IDAL;
using Note.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Note.DAL {
    public class NoticeDal :INoticeDal {

        private readonly IConfiguration _configuration;

        public NoticeDal(IConfiguration configuration) {
            _configuration = configuration; 
        }
        public List<Notice> GetNoticeList() {
            using (var db = new NoteDbContext(_configuration)) {
                return db.Notices.OrderByDescending(n=>n.NoticeNo).ToList();
            }
        }

        public Notice GetNotice(int noticeNo) {
            throw new NotImplementedException();
        }

        public bool PostNotice(Notice notice) {
            throw new NotImplementedException();
        }

        public bool UpdateNotice(Notice notice) { 
            throw new NotImplementedException();
        }
        public bool DeleteNotice(int noticeNo) {
            throw new NotImplementedException();
        }
    }
}
