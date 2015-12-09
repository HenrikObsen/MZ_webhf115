using System.Web.Mvc;
using RepoMZ;

namespace MZ_webhf115.Areas.Admin.Controllers
{
    public class aKategoriController : Controller
    {
        private KategoriFac katFac = new KategoriFac();

        // GET: Admin/aKategori
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddKat(Kategori kat)
        {
            if (ModelState.IsValid)
            {
                katFac.Insert(kat);
                ViewBag.MSG = "Kategorien er oprettet!";
            }
            else
            {
                ViewBag.MSG = "Udfyld alle felter!!!";
            }

            
            return View("Index");
        }

        public ActionResult Edit()
        {
            return View(katFac.GetAll());
        }
        
        public ActionResult EditForm(int id)
        {
            return View(katFac.Get(id));
        }

        [HttpPost]
        public ActionResult EditResult(Kategori kat)
        {
            if (ModelState.IsValid)
            {
                katFac.Update(kat);
            }

            return RedirectToAction("Edit");
        }


        public ActionResult Delete(int id)
        {
            katFac.Delete(id);
            return RedirectToAction("Edit");
        }

    }
}