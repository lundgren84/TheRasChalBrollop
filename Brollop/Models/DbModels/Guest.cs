using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Brollop.Models.DbModels
{
    public enum GuestStatus
    {
        NotAwnsered,NotComming,Comming
    }
    public class Guest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public GuestStatus OSAStatus { get; set; }
        public string Song { get; set; }
        public string Allergy { get; set; }
        public int InvitationRefId { get; set; }
        [ForeignKey("InvitationRefId")]
        public Invitation Invitation { get; set; }
    }
}