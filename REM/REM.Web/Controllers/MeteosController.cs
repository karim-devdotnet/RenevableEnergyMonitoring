using REM.Data;
using REM.Model.Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace REM.Web.Controllers
{
    [Authorize]
    public class MeteosController : Controller
    {
        private REMContext db = new REMContext();

        // GET: Meteos
        public ActionResult Index()
        {
            return View(db.Meteos.ToList());
        }

        // GET: Meteos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meteo meteo = db.Meteos.Find(id);
            if (meteo == null)
            {
                return HttpNotFound();
            }
            return View(meteo);
        }

        // GET: Meteos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meteos/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Timestamp,Irradiance,TemperatureOfModule,TemperatureAmbiante,Humidity,SpeedOfWind")] Meteo meteo)
        {
            if (ModelState.IsValid)
            {
                db.Meteos.Add(meteo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meteo);
        }

        // GET: Meteos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meteo meteo = db.Meteos.Find(id);
            if (meteo == null)
            {
                return HttpNotFound();
            }
            return View(meteo);
        }

        // POST: Meteos/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Timestamp,Irradiance,TemperatureOfModule,TemperatureAmbiante,Humidity,SpeedOfWind")] Meteo meteo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meteo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meteo);
        }

        // GET: Meteos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meteo meteo = db.Meteos.Find(id);
            if (meteo == null)
            {
                return HttpNotFound();
            }
            return View(meteo);
        }

        // POST: Meteos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Meteo meteo = db.Meteos.Find(id);
            db.Meteos.Remove(meteo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
