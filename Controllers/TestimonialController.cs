using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class TestimonialController : Controller
    {
        YummyDbContext _dbContext= new YummyDbContext();    
        // GET: Testimonial
        public ActionResult Index()
        {
            return View(_dbContext.Testimonials.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Testimonial testimonial)
        {
            if(testimonial.ImageFile != null)
            {
                var currentDirectory=AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets//";
                var fileName=Path.Combine(saveLocation, testimonial.ImageFile.FileName);
                testimonial.ImageFile.SaveAs(fileName); 
                testimonial.ImageUrl="/assets/" + testimonial.ImageFile.FileName;
            }
            _dbContext.Testimonials.Add(testimonial);
            _dbContext.SaveChanges(); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_dbContext.Testimonials.Find(id));
            
        }
        [HttpPost]  
        public ActionResult Update(Testimonial testimonial)
        {
            var model = _dbContext.Testimonials.Find(testimonial.TestimonialId);

            if (testimonial.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets//";
                var fileName = Path.Combine(saveLocation, testimonial.ImageFile.FileName);
                testimonial.ImageFile.SaveAs(fileName);
                model.ImageUrl = "/assets/" + testimonial.ImageFile.FileName;
            }
            model.Title = testimonial.Title;
            model.Comment=testimonial.Comment;
            model.FullName = testimonial.FullName;
            model.Rating = testimonial.Rating;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}