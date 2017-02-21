using System.Linq;
using System.Web.Http;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
{
    public class DaysOfWeekController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DaysOfWeek
        public IQueryable<DaysOfWeek> GetDaysOfWeek()
        {
            return db.DaysOfWeek;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DaysOfWeekExists(int id)
        {
            return db.DaysOfWeek.Count(e => e.Id == id) > 0;
        }
    }
}