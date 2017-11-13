using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brollop.Models.ViewModels
{
    public class VIP_Model
    {
        public string Name { get; set; }
        public string Titel { get; set; }
        public string Phone { get; set; }
        public ImgModel Portrait { get; set; }
        public string Description { get; set; }
    }
}