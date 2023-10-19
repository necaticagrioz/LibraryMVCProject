using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;

namespace LibraryMVCProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var deger = db.TblKategori.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TblKategori p)
        {
            db.TblKategori.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TblKategori.Find(id);
            db.TblKategori.Remove(kategori);
            db.SaveChanges();   
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TblKategori.Find(id);
            return View("KategoriGetir",ktg);
        }
        public ActionResult KategoriGuncelle(TblKategori p)
        {
            var ktg = db.TblKategori.Find(p.ID);
            ktg.Ad = p.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}