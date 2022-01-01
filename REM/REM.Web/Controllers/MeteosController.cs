using PagedList;
using REM.Data;
using REM.Model.Entities;
using REM.Web.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace REM.Web.Controllers
{
    [Authorize]
    public class MeteosController : BaseController
    {
        private REMContext db = new REMContext();

        // GET: Meteos
        public ActionResult Index(string sortOrder, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.TimestampSortParam = sortOrder == "Timestamp" ? "Timestamp_desc" : "Timestamp";
            ViewBag.IrradianceSortParam = sortOrder == "Irradiance" ? "Irradiance_desc" : "Irradiance";
            ViewBag.TemperatureOfModuleSortParam = sortOrder == "TemperatureOfModule" ? "TemperatureOfModule_desc" : "TemperatureOfModule";
            ViewBag.TemperatureAmbianteSortParam = sortOrder == "TemperatureAmbiante" ? "TemperatureAmbiante_desc" : "TemperatureAmbiante";
            ViewBag.HumiditySortParam = sortOrder == "Humidity" ? "Humidity_desc" : "Humidity";
            ViewBag.SpeedOfWindSortParam = sortOrder == "SpeedOfWind" ? "SpeedOfWind_desc" : "SpeedOfWind";
            ViewBag.SearchString = searchString;
            ViewBag.CurrentSortOrder = sortOrder;

            var meteos = db.Meteos.ToList();

            var searchStringToLower = searchString?.ToLower();
            if (!string.IsNullOrEmpty(searchStringToLower))
            {
                meteos = meteos.Where(x => x.Timestamp.ToLongTimeString().Contains(searchStringToLower)
                            || x.Irradiance.ToString().Contains(searchStringToLower)
                            || x.TemperatureOfModule.ToString().Contains(searchStringToLower)
                            || x.TemperatureAmbiante.ToString().Contains(searchStringToLower)
                            || x.Humidity.ToString().Contains(searchStringToLower)
                            || x.SpeedOfWind.ToString().Contains(searchStringToLower)).ToList();
            }

            switch (sortOrder)
            {
                case "Timestamp":
                    meteos = meteos.OrderBy(x => x.Timestamp).ToList();
                    break;
                case "Irradiance_desc":
                    meteos = meteos.OrderByDescending(x => x.Irradiance).ToList();
                    break;
                case "Irradiance":
                    meteos = meteos.OrderBy(x => x.Irradiance).ToList();
                    break;
                case "TemperatureOfModule_desc":
                    meteos = meteos.OrderByDescending(x => x.TemperatureOfModule).ToList();
                    break;
                case "TemperatureOfModule":
                    meteos = meteos.OrderBy(x => x.TemperatureOfModule).ToList();
                    break;
                case "TemperatureAmbiante_desc":
                    meteos = meteos.OrderByDescending(x => x.TemperatureAmbiante).ToList();
                    break;
                case "TemperatureAmbiante":
                    meteos = meteos.OrderBy(x => x.TemperatureAmbiante).ToList();
                    break;
                case "Humidity_desc":
                    meteos = meteos.OrderByDescending(x => x.Humidity).ToList();
                    break;
                case "Humidity":
                    meteos = meteos.OrderBy(x => x.Humidity).ToList();
                    break;
                case "SpeedOfWind_desc":
                    meteos = meteos.OrderByDescending(x => x.SpeedOfWind).ToList();
                    break;
                case "SpeedOfWind":
                    meteos = meteos.OrderBy(x => x.SpeedOfWind).ToList();
                    break;
                default:
                    meteos = meteos.OrderByDescending(x => x.Timestamp).ToList();
                    break;
            }

            int pageSize = 10;
            int pageNumber = page ?? 1;


            var model = new MeteosListViewModel();
            model.MeteoPagedList = meteos.ToPagedList(pageNumber, pageSize);


            ViewBag.ReturnUrl = GetReturnUrl();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_UserList", model);
            }

            return View(model);
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

        public ActionResult GraphicPreview()
        {
            return View();
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
