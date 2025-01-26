using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class ServiceController : Controller
    {
        YummyDbContext _dbContext=new YummyDbContext();
        // GET: Service
        public ActionResult Index()
        {
            return View(_dbContext.Services.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Service service)
        { 
            _dbContext.Services.Add(service);   
            _dbContext.SaveChanges();   
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            return View(_dbContext.Services.Find(id));

        }
        [HttpPost]
        public ActionResult Update(Service service)
        {
           var model=_dbContext.Services.Find(service.ServiceId);
            model.Title = service.Title;    
            model.Description = service.Description;
            model.Icon = service.Icon; 
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
           _dbContext.Services.Remove(_dbContext.Services.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}