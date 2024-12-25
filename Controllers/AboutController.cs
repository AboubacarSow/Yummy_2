using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class AboutController : Controller
    {
        YummyDbContext _dbContext = new YummyDbContext();   
        // GET: About
        public ActionResult Index()
        {
            return View(_dbContext.Abouts.ToList());
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Abouts.Remove(_dbContext.Abouts.FirstOrDefault(a=>a.AboutId == id)); 
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(About about)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir Hata Oluşmuştur");
                return View(about);
            }
            _dbContext.Abouts.Add(about);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_dbContext.Abouts.Find(id));
        }
        [HttpPost]  
        public ActionResult Update(About about)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bir Hata Oluşmuştur");
                return View(about);
            }
            var value = _dbContext.Abouts.Find(about.AboutId);
            value.ImageUrl = about.ImageUrl;    
            value.Item_1 = about.Item_1;    
            value.Item_2 = about.Item_2;
            value.Item_3= about.Item_3; 
            value.VideoUrl = about.VideoUrl;    
            value.PhoneNumber = about.PhoneNumber;  
            value.Description = about.Description;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}