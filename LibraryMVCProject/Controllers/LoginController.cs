using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;
using System.Web.Security;

namespace LibraryMVCProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TblUyeler p)
        {
            var bilgi = db.TblUyeler.FirstOrDefault(x=>x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Mail, false);
                Session["Mail"] = bilgi.Mail.ToString();
                //TempData["Ad"] = bilgi.Ad.ToString();
                //TempData["Soyad"] = bilgi.Soyad.ToString();
                //TempData["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                //TempData["Sifre"] = bilgi.Sifre.ToString();
                //TempData["Okul"] = bilgi.Okul.ToString();
                //TempData["ID"] = bilgi.ID.ToString();
                return RedirectToAction("Index", "Panel");
            }
            else
            {
            return View();

            }
        }
    }
}