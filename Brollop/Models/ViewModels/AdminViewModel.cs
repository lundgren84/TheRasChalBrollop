using Brollop.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brollop.Models.ViewModels
{
    public class AdminViewModel
    {
        public List<Invitation> Invitations { get; set; }
        public SiteSetting SiteSetting { get; set; }
        //public InvitationModel PageInvitation { get; set; }
        //public List<VIP_Model> VIP_Perssons { get; set; }
        //public LoveStoryModel LoveStory { get; set; }        
    }
}