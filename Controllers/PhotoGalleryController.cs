using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class PhotoGalleryController : Controller
    {
        YummyDbContext _dbContext = new YummyDbContext();   
        // GET: PhotoGallery
        public ActionResult Index()
        {
            return View(_dbContext.PhotoGalleries.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PhotoGallery photoGallery)
        {
            if(photoGallery.ImageFile != null)
            {
                var currentDirectory=AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets//";
                var fileName= Path.Combine(saveLocation, photoGallery.ImageFile.FileName);
                photoGallery.ImageFile.SaveAs(fileName);
                photoGallery.ImageUrl= "/assets/" +photoGallery.ImageFile.FileName;
            }
            _dbContext.PhotoGalleries.Add(photoGallery);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            return View(_dbContext.PhotoGalleries.Find(id));

        }
        [HttpPost]
        public ActionResult Update(PhotoGallery photoGallery)
        {
            var model=_dbContext.PhotoGalleries.FirstOrDefault(p=>p.Id==photoGallery.Id);
            if(photoGallery.ImageFile!= null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "assets//";
                var fileName = Path.Combine(saveLocation, photoGallery.ImageFile.FileName);
                photoGallery.ImageFile.SaveAs(fileName);
                model.ImageUrl="/assets/" + photoGallery.ImageFile.FileName;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _dbContext.PhotoGalleries.Remove(_dbContext.PhotoGalleries.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}