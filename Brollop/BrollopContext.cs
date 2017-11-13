using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Brollop.Models.DbModels;

namespace Brollop
{
    public class BrollopContext : DbContext { 
        public BrollopContext() : base("name = BrollopConnectionString") { }

        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }
}