using Brollop.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brollop.Models.ViewModels
{
    public class MasterViewModel
    {
        public Invitation Invitation { get; set; }
        public SiteSetting SiteSetting { get; set; }
        //public InvitationModel PageInvitation { get; set; }
        //public List<VIP_Model> VIP_Perssons { get; set; }
        //public LoveStoryModel LoveStory { get; set; }
    }
}