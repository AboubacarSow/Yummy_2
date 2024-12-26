using System.Linq;
using System.Web.Mvc;
using Yummy_2.Models;

namespace Yummy_2.Controllers
{
    public class BookingController : Controller
    {
        YummyDbContext _dbContext=new YummyDbContext();
        // GET: Booking
        public ActionResult Index()
        {
            return View(_dbContext.Bookings.ToList());
        }
        public ActionResult Approving(int id)
        {
            var booking= _dbContext.Bookings.FirstOrDefault(b=>b.BookingId==id);
            booking.IsApproved=true;    
            _dbContext.SaveChanges();   
            return RedirectToAction("Index");   
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Bookings.Remove(_dbContext.Bookings.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}