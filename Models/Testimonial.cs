﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yummy_2.Models
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string FullName { get; set; }
        public string ImageUrl {  get; set; }   
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating {  get; set; }    
    }
}