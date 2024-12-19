using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yummy_2.Models
{
    public class Event
    {
        public int EventId { get; set; }    
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}