using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brollop.Models.DbModels
{
    public class Invitation
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Guest> Guests { get; set; }
        public bool Admin { get; set; }
    }
}