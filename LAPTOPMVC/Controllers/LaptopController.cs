using LAPTOPMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace LAPTOPMVC.Controllers
{
    public class LaptopController : Controller
    {
        public LaptopContext db = new LaptopContext();

        // GET: Laptop
        public ActionResult Index()
        {
            return View(new LaptopDAO().getList());
        }

        [HttpGet]
        public ActionResult Editmay(string id)
        {
            ViewBag.Loai = 1;
            var lap = db.laptop.FirstOrDefault(l => l.id == id);
            if (lap == null)
            {
                return RedirectToAction("Index");
            }
            return View("Addmay", lap);
        }

        public ActionResult Editmay(Laptop model)
        {
            ViewBag.Loai = 1;
            if (ModelState.IsValid)
            {
                var lap = db.laptop.FirstOrDefault(l => l.id == model.id);
                lap.name = model.name;
                lap.price = model.price;
                lap.cpu = model.cpu;
                lap.ram = model.ram;
                lap.storage = model.storage;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Addmay()
        {
            ViewBag.Loai = 0;
            return View(new Laptop());
        }

        [HttpPost]
        public ActionResult Addmay(Laptop model)
        {
            ViewBag.Loai = 0;
            if (ModelState.IsValid)
            {
                db.laptop.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public JsonResult Deletemay(string id)
        {
            var lap = db.laptop.FirstOrDefault(l => l.id == id);
            if (lap == null)
            {
                return Json(new { isvalid = false, msg = "Not Found" });
            }
            db.laptop.Remove(lap);
            db.SaveChanges();
            return Json(new { isvalid = true, msg = "Deleted" });
        }
    }
}