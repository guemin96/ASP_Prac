using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASPNETIdentityTest {
    public class ApplicationUser : IdentityUser {

        public string MyColor { get; set; }

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext() :base("DefaultConnection") {

        }
    }
    public class UserManager : UserManager<ApplicationUser> {
        public UserManager() : base (new UserStore<ApplicationUser>(new ApplicationDbContext())) { 
        
        }
    }
}