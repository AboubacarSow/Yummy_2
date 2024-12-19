using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yummy_2.Models
{
    public class ChefSocial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon {  get; set; }   
        public int ChefId {  get; set; }    
        public virtual Chef Chef {  get; set; } 
    }
}