using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yummy_2.Models
{
    public class Message
    {
        public int MessageId {  get; set; }
        public string Name {  get; set; }   
        public string Email {  get; set; }  
        public string Subject {  get; set; }    
        public string MessageBody { get; set; }    
        public bool IsRead { get; set; }
    }
}