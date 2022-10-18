using Hi.Model;
using System.Collections.Generic;

namespace Hi.IDAL {
    public interface IUserDal {
        List<User> GetUserList();
        
        User GetUser(int id);

        bool SaveUser(User user);
    }
}