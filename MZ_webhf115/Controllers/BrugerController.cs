using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using RepoMZ;

namespace MZ_webhf115.Controllers
{
    public class BrugerController : Controller
    {
        BrugerFac brugerFac = new BrugerFac();
        // GET: Bruger
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            Bruger bruger = brugerFac.Login(Email.Trim(), Crypto.Hash(Password.Trim()));

            if (bruger.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(bruger.ID.ToString(),true);

                Session["UserID"] = bruger.ID;
                Session["Level"] = bruger.Level;
                Session.Timeout = 120;
                return Redirect("/Bruger/Secret/");
            }
            else
            {
                ViewBag.MSG = "Brugeren blev ikke fundet!!!";
                return View("Index");
            }


        }
        
        [Authorize]
        public ActionResult Secret()
        {
            return View();
        }
    }
}