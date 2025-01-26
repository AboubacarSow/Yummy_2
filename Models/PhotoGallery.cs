using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Yummy_2.Models
{
    public class PhotoGallery
    {
        public int Id { get; set; } 
        public string ImageUrl {  get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }   
    }
}