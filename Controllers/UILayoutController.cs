using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    [AllowAnonymous]
    public class UILayoutController : Controller
    {
        YummyDbContext _dbContext = new YummyDbContext();   
        // GET: UILayout
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SocialMedia()
        {
            return PartialView(_dbContext.SocialMedias.ToList());
        }
        public PartialViewResult ContactLayout()
        {
            return PartialView(_dbContext.ContactInfos.ToList());
        }
    }
}