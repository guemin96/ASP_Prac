using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using Note.IDAL;
using Note.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Note.BLL
{
    public class UserBll : IUserDal
    {
        private readonly IUserDal _userDal;

        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUser(int userNo)
        {
            return _userDal.GetUser(userNo);
        }

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}