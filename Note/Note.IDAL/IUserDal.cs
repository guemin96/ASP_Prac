using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using Note.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Note.IDAL
{
    public interface IUserDal
    {
        List<User> GetUserList();

        User GetUser(int userNo);
        
    }
}