using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        YummyDbContext _dbContext=new YummyDbContext(); 
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultFeature()
        {
            return PartialView(_dbContext.Features.ToList());   
        }
        public PartialViewResult DefaultAbout()
        {
            return PartialView(_dbContext.Abouts.ToList());
        }
        public PartialViewResult DefaultCategory()
        {
            return PartialView(_dbContext.Categories.ToList()); 
        }
        [HttpGet]
        public PartialViewResult BookingTable()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult BookingTable(Booking booking)
        {
            booking.BookingDate.AddHours(booking.Time);
            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult Event()
        {
            return PartialView(_dbContext.Events.ToList());
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}