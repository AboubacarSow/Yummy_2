using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yummy_2.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string Address {  get; set; }    
        public string Email {  get; set; }  
        public string PhoneNumber {  get; set; }    
        public string MapUrl {  get; set; } 
        public string OpenHours {  get; set; }  
    }
}