using LibraryMVCProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryMVCProject.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TblAdmin p)
        {
            var bilgi = db.TblAdmin.FirstOrDefault(x=>x.Kullanici ==p.Kullanici && x.Sifre ==p.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Kullanici, false);
                Session["Kullanici"] = bilgi.Kullanici.ToString();
                return RedirectToAction("Index", "Statistics");
            }
            else
            {
            return View();

            }
        }
    }
}