using System.Web.Mvc;
using RepoMZ;

namespace MZ_webhf115.Controllers
{
    public class ProduktController : Controller
    {
        ProduktFac prodFac = new ProduktFac();

        // GET: Produkt
        public ActionResult ProduktListe(int id=1)
        {
            return View(prodFac.GetProduktListe(id));
        }
    }
}

