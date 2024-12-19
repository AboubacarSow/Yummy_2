using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yummy_2.Models
{
    public class About
    {
        public int AboutId { get; set; }

        public string ImageUrl { get; set; }
        public string Item_1 { get; set; }  
        public string Item_2 { get; set; }  
        public string Item_3 { get; set; }  
        public string Description { get; set; }
        public string VideoUrl {  get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl_1 { get; set; }
    }
}