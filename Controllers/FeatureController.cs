using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
 
    public class FeatureController : Controller
    {
        YummyDbContext _dbContext = new YummyDbContext();   
        // GET: Feature
        public ActionResult Index()
        {
            return View(_dbContext.Features.ToList());
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Features.Remove(_dbContext.Features.Find(id));
            _dbContext.SaveChanges();   
            return RedirectToAction("Index");   
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dbContext.Features.Add(feature);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            return View(_dbContext.Features.Find(id));
        }
        [HttpPost]
        public ActionResult Update(Feature feature)
        {
            Feature model= _dbContext.Features.Find(feature.FeatureId);
            model.Title = feature.Title;
            model.Description = feature.Description;
            model.ImageUrl = feature.ImageUrl;
            model.VideoUrl = feature.VideoUrl;  
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}