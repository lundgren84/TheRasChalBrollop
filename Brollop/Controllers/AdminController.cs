using Brollop.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brollop.Models.DbModels;

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
                model.Guests = ctx.Guests.ToList();
                foreach (var item in model.Invitations)
                {
                    item.Guests = ctx.Guests.Where(x => x.InvitationRefId == item.Id).ToList();
                }
            }
          
      
            return View(model);
        }
    }
}