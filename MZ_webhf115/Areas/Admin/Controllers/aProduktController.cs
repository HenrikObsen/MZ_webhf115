using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
using RepoMZ;
using RepoMZ.Models.ViewModels;

namespace MZ_webhf115.Areas.Admin.Controllers
{
    public class aProduktController : Controller
    {
        KategoriFac katFac = new KategoriFac();
        ProduktFac pf = new ProduktFac();
        Uploader uploader = new Uploader();

        #region Add

        // GET: Admin/aProdukt
        public ActionResult Add()
        {
            return View(katFac.GetAll());
        }

        [HttpPost]
        public ActionResult AddResult(Produkt prod, HttpPostedFileBase fil)
        {
            if (fil != null)
            {
                string path = Request.PhysicalApplicationPath + "Content/Images/";
                prod.Billede = Path.GetFileName(uploader.UploadImage(fil, path, 300, true));
            }
            else
            {
                prod.Billede = "På vej.jpg";
            }

            pf.Insert(prod);
            ViewBag.MSG = "Produktet er oprettet'!";

            return View("Add", katFac.GetAll());
        }

        #endregion


        #region Edit
        public ActionResult Edit()
        {
            EditProduct ep = new EditProduct();
            ep.Kategorier = katFac.GetAll();
            return View(ep);
        }

        public ActionResult EditList(int KatID)
        {
            EditProduct ep = new EditProduct();
            ProduktListe pl = new ProduktListe();
            ep.Kategorier = katFac.GetAll();
            pl.Produkter = pf.GetBy("KatID", KatID);
            pl.Kategori = katFac.Get(KatID);
            ep.Produktliste = pl;

            return View("Edit", ep);
        }
        public ActionResult EditForm(int id)
        {
            EditProduktForm epf = new EditProduktForm();
            epf.Kategorier = katFac.GetAll();
            epf.Produkt = pf.Get(id);
            return View(epf);
        }

        [HttpPost]
        public ActionResult EditResult(Produkt prod, HttpPostedFileBase fil)
        {
            if (fil != null)
            {
                string path = Request.PhysicalApplicationPath + "Content/Images/";
                prod.Billede = Path.GetFileName(uploader.UploadImage(fil, path, 300, true));
            }
            else
            {
                prod.Billede = "På vej.jpg";
            }

            pf.Update(prod);


            EditProduktForm epf = new EditProduktForm();
            epf.Kategorier = katFac.GetAll();
            epf.Produkt = pf.Get(prod.ID);
            ViewBag.MSG = "Produktet er opdateret'!";

            return View("EditForm", epf);
        }

        public ActionResult Delete(int id)
        {
            pf.Delete(id);
            return RedirectToAction("Edit");
        }
        #endregion


    }
}