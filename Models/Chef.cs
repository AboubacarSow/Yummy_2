using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yummy_2.Models
{
    public class Chef
    {
        public int ChefId { get; set; } 
        public string FullName { get; set; }
        public string Description { get; set; }

        public string Title {  get; set; }  
        public string ImageUrl {  get; set; }  
        
        public virtual List<ChefSocial> ChefSocials { get; set; }       
    }
}