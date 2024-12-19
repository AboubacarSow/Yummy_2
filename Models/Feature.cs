using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yummy_2.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }

        [Required(ErrorMessage ="Resim Alanı Boş Bırakılamaz!")] 
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Başlık Alanı Boş Bırakılamaz!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama Alanı Boş Bırakılamaz!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Video Alanı Boş Bırakılamaz!")]
        public string VideoUrl { get; set; }
    }
}