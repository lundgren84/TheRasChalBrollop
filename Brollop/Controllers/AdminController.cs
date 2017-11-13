using Brollop.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Brollop.Controllers
{
 

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {


        public AdminController()
        {

        }

        // GET: Admin
        public ActionResult Index()
        {
            var model = new AdminViewModel();
            using(var ctx = new BrollopContext())
            {
                model.SiteSetting = ctx.SiteSettings.FirstOrDefault();
                model.Invitations = ctx.Invitations.ToList();
            }
      
            return View(model);
        }
    }
}