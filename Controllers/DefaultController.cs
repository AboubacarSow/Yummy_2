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
            if (TimeSpan.TryParse(booking.Time, out TimeSpan timeSpan))
            {

                booking.BookingDate = booking.BookingDate.Date.Add(timeSpan); // Ajout de l'heure
             
            }
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
        public PartialViewResult Services()
        {
            return PartialView(_dbContext.Services.ToList());
        }
        public PartialViewResult NProducts()
        {
            return PartialView(_dbContext.Products.ToList().Count());
        }
        public PartialViewResult NKategories()
        {
            return PartialView(_dbContext.Categories.ToList().Count());
        }
        public PartialViewResult NEvents()
        {
            return PartialView(_dbContext.Events.ToList().Count()); 
        }
        public PartialViewResult NChefs()
        {
            return PartialView(_dbContext.Chefs.ToList().Count()); 
        }
        public PartialViewResult DefaultTestimonials()
        {
            return PartialView(_dbContext.Testimonials.ToList());
        }
        public PartialViewResult DefaultChefs()
        {
            return PartialView(_dbContext.Chefs.ToList());
        }
        public PartialViewResult DefaultGallery()
        {
            return PartialView(_dbContext.PhotoGalleries.ToList());
        }
        public PartialViewResult DefaultContact()
        {
            return PartialView(_dbContext.ContactInfos.ToList());
        }
    }
}