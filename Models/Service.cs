﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yummy_2.Models
{
    public class Service
    {
        public int ServiceId {  get; set; } 
        public string Title {  get; set; }  
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}