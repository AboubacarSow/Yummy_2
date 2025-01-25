using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class EventController : Controller
    {
        YummyDbContext _dbContext=new YummyDbContext();
        // GET: Event
        public ActionResult Index()
        {
            return View(_dbContext.Events.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Event model)
        {
            _dbContext.Events.Add(model);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Events.Remove(_dbContext.Events.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            return View(_dbContext.Events.Find(id));
        }
        [HttpPost]
        public ActionResult Update(Event model)
        {
            var value=_dbContext.Events.FirstOrDefault(c=>c.EventId==model.EventId);
            value.Title = model.Title;
            value.Description = model.Description;
            value.Price= model.Price;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}