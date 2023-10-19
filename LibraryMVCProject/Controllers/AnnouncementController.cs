using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;

namespace LibraryMVCProject.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var deger = db.TblDuyuru.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniDuyuru() 
        {
            return View();  
        }
        [HttpPost]
        public ActionResult YeniDuyuru(TblDuyuru t)
        {
            db.TblDuyuru.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TblDuyuru.Find(id);
            db.TblDuyuru.Remove(duyuru);
            db.SaveChanges();   
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(TblDuyuru p)
        {
            var duyuru = db.TblDuyuru.Find(p.ID);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGuncelle(TblDuyuru t)
        {
            var duyuru = db.TblDuyuru.Find(t.ID);
            duyuru.Kategori = t.Kategori;
            duyuru.Icerik = t.Icerik;
            duyuru.Tarih = t.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}