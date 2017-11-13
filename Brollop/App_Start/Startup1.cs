using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartup(typeof(Brollop.App_Start.Startup1))]

namespace Brollop.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Authentication/Login")
                });
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            var context = new BrollopIdentityDbContext();
            var store = new UserStore<IdentityUser>(context);
            var userManager = new UserManager<IdentityUser>(store);
            var  roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new IdentityUser();
                user.UserName = "admin";

                string userPWD = "admin12";

                var chkUser = userManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");

                }
            }

            //// creating Creating Manager role    
            //if (!roleManager.RoleExists("Manager"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Manager";
            //    roleManager.Create(role);

            //}

            //// creating Creating Employee role    
            //if (!roleManager.RoleExists("Employee"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Employee";
            //    roleManager.Create(role);

            //}
        }
    }
}
