using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class ChefSocialMediaController : Controller
    {
        YummyDbContext _dbContext = new YummyDbContext();   
        // GET: ChefSocialMedia
        public ActionResult Index()
        {
            return View(_dbContext.ChefSocials.ToList());
        }
        public ActionResult Create()
        {
            GetChefs();
            return View();
        }
        [HttpPost]
        public ActionResult Create(ChefSocial social)
        {
            if (!ModelState.IsValid)
            {
                GetChefs() ;    
                ModelState.AddModelError("", "Bir hata oluşmuştur");
                return View(social);
            }
            social.Chef=_dbContext.Chefs.FirstOrDefault(c=>c.ChefId == social.ChefId);
            _dbContext.ChefSocials.Add(social);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        private void GetChefs() 
        {
            ViewBag.Chefs=(from c in _dbContext.Chefs.ToList()
                           select new SelectListItem
                           {
                               Text= c.FullName,
                               Value=c.ChefId.ToString()
                           }).ToList();

        }
        public ActionResult Update(int id)
        {
            GetChefs();
            return View(_dbContext.ChefSocials.Find(id));  
            
        }
        public ActionResult Update(ChefSocial social)
        {
            if (!ModelState.IsValid)
            {
                GetChefs();
                ModelState.AddModelError("", "Bir hata oluştu");
                return View(social);    
            }
            var value=_dbContext.ChefSocials.FirstOrDefault(x=>x.Id==social.Id);
            value.Name = social.Name;
            value.Icon = social.Icon;
            value.Url = social.Url;
            value.Chef = _dbContext.Chefs.First(c => c.ChefId == social.ChefId);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _dbContext.ChefSocials.Remove(_dbContext.ChefSocials.Find(id));
            _dbContext.SaveChanges();
            return View("Index");
        }
    }
}