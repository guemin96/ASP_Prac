using Hi.IDAL;
using Hi.Model;
using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hi.Oracle.DAL {
    public class UserDal : IUserDal {
        public User GetUser(int id) {
            throw new NotImplementedException();
        }

        public List<User> GetUserList() {
            throw new NotImplementedException();
        }

        public bool SaveUser(User user) {
            throw new NotImplementedException();
        }
    }
}