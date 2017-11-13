using Brollop.Models.DbModels;
using Brollop.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Brollop.Controllers
{
    public class AuthenticationController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public AuthenticationController()
        {
            var context = new BrollopIdentityDbContext();
            var store = new UserStore<IdentityUser>(context);
            userManager = new UserManager<IdentityUser>(store);
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }
        // GET: Authentication
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new IdentityUser
            {
                UserName = model.Username,
            };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var identity = await userManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);



                var authorisationManager =
                    HttpContext.GetOwinContext().Authentication;
                //Sign in
                //authorisationManager.SignIn(identity);
         

            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await userManager.FindAsync(model.Username, model.Password);
            if (user == null) { return View(); }

            var identity = await userManager.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie);
            var authorisationManager = HttpContext.GetOwinContext().Authentication;
            authorisationManager.SignIn(identity);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            var authorisationManager = HttpContext.GetOwinContext().Authentication;
            authorisationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login");
        }
    }
}