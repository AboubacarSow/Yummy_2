using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class SocialMediaController : Controller
    {
        YummyDbContext _dbContext=new YummyDbContext(); 
        // GET: SocialMedia
        public ActionResult Index()
        {
            return View(_dbContext.SocialMedias.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult Create(SocialMedia media)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hata oluşmuştur");
                return View(media); 
            }
            _dbContext.SocialMedias.Add(media);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update (int id)
        {
            return View(_dbContext.SocialMedias.Find(id));
        }
        [HttpPost]
        public ActionResult Update(SocialMedia media)
        {
            var model=_dbContext.SocialMedias.Find(media.Id);
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hata oluşmuştur");
                return View(media);
            }
            model.Title = media.Title;  
            model.Icon = media.Icon;    
            model.Url = media.Url;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete (int id)
        {
            _dbContext.SocialMedias.Remove(_dbContext.SocialMedias.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}