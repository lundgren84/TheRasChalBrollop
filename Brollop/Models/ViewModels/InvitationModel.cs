﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brollop.Models.ViewModels
{
    public class InvitationModel
    {
        public string Heading { get; set; }
        public string Ingress { get; set; }
        public string Content { get; set; }
        public ImgModel Image { get; set; }
    }
}