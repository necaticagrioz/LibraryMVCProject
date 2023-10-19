using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;
namespace LibraryMVCProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var deger = db.TblYazar.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TblYazar p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TblYazar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TblYazar.Find(id);
            db.TblYazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TblYazar.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TblYazar p)
        {
            var yzr = db.TblYazar.Find(p.ID);
            yzr.Ad = p.Ad;
            yzr.Soyad = p.Soyad;
            yzr.Detay = p.Detay;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.TblKitap.Where(x=>x.Yazar == id).ToList();
            var yazarAd = db.TblYazar.Where(y=>y.ID == id).Select(z=>z.Ad + " " + z.Soyad).FirstOrDefault();
            ViewBag.y1 = yazarAd;
            return View(yazar);
        }
    }
}