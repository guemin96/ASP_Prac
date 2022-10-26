using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;


using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(ASPNETIdentityTest.Startup))]

namespace ASPNETIdentityTest {
    public class Startup {
        public void Configuration(IAppBuilder app) {

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login.aspx")
            });
        }
    }
}
