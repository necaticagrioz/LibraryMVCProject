using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;
namespace LibraryMVCProject.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index(string p)
        {
            var kitap = from k in db.TblKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitap = kitap.Where(m => m.Ad.Contains(p));
            }
            //var kitap = db.TblKitap.ToList();
            return View(kitap.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TblKitap p)
        {
            var ktg = db.TblKategori.Where(k => k.ID == p.TblKategori.ID).FirstOrDefault();
            var yzr = db.TblYazar.Where(y => y.ID == p.TblYazar.ID).FirstOrDefault();
            p.TblKategori = ktg;
            p.TblYazar = yzr;
            db.TblKitap.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TblKitap.Find(id);
            db.TblKitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TblKitap.Find(id);
            List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + ' ' + i.Soyad,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGuncelle(TblKitap p)
        {
            var kitap = db.TblKitap.Find(p.ID);
            kitap.Ad = p.Ad;
            kitap.BasimYil = p.BasimYil;
            kitap.Sayfa = p.Sayfa;
            kitap.Yayinevi = p.Yayinevi;
            kitap.KitapFoto = p.KitapFoto;
            var ktg = db.TblKategori.Where(k=>k.ID == p.TblKategori.ID).FirstOrDefault();
            var yzr = db.TblYazar.Where(y => y.ID == p.TblYazar.ID).FirstOrDefault();
            kitap.Kategori = ktg.ID;
            kitap.Yazar = yzr.ID;
            kitap.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}