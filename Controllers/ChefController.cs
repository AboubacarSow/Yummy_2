using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class ChefController : Controller
    {
        YummyDbContext _dbContext=new YummyDbContext(); 
        // GET: Chef
        public ActionResult Index()
        {
            return View(_dbContext.Chefs.ToList());
        }
        public ActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Create(Chef chef)
        {
            _dbContext.Chefs.Add(chef);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            return View(_dbContext.Chefs.Find(id));
        }
        [HttpPost]
        public ActionResult Update(Chef chef)
        {
            var value=_dbContext.Chefs.FirstOrDefault(c=>c.ChefId==chef.ChefId);
            value.FullName = chef.FullName; 
            value.Title = chef.Title;   
            value.Description = chef.Description;
            value.ImageUrl = chef.ImageUrl;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _dbContext.Chefs.Remove(_dbContext.Chefs.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}