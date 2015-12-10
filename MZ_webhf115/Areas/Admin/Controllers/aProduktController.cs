using System.IO;
using System.Web;
using System.Web.Mvc;
using RepoMZ;

namespace MZ_webhf115.Areas.Admin.Controllers
{
    public class aProduktController : Controller
    {
        KategoriFac katFac = new KategoriFac();
        ProduktFac pf = new ProduktFac();
        Uploader uploader = new Uploader();

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
    }
}