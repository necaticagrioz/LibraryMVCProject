using LibraryMVCProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVCProject.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var kullanici = db.TblAdmin.ToList();
            return View(kullanici);
        }
        public ActionResult Index2()
        {
            var kullanici = db.TblAdmin.ToList();
            return View(kullanici);
        }
        public ActionResult YeniAdmin()
        {
            return View();  
        }
        public ActionResult YeniAdmin(TblAdmin t)
        {
            db.TblAdmin.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminSil(int id)
        {
            var admin=db.TblAdmin.Find(id);
            db.TblAdmin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = db.TblAdmin.Find(id);
            return View("AdminGuncelle", admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TblAdmin p)
        {
            var admin = db.TblAdmin.Find(p.ID);
            admin.Kullanici = p.Kullanici;
            admin.Sifre = p.Sifre;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}