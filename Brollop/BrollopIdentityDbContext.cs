﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brollop
{
    public class BrollopIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public BrollopIdentityDbContext() : base("name = BrollopConnectionString") { }


    }
}