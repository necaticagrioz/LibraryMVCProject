using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace LibraryMVCProject.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index(int sayfalar = 1)
        {
            //var deger = db.TblUyeler.ToList();
            var deger = db.TblUyeler.ToList().ToPagedList(sayfalar, 3);
            return View(deger);
        }
        [HttpGet]
        public ActionResult UyeEkle() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TblUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TblUyeler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TblUyeler.Find(id);
            db.TblUyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TblUyeler.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TblUyeler p)
        {
            var uye = db.TblUyeler.Find(p.ID);
            uye.Ad = p.Ad;
            uye.Soyad = p.Soyad;
            uye.Mail = p.Mail;
            uye.KullaniciAdi = p.KullaniciAdi;
            uye.Sifre = p.Sifre;
            uye.Okul = p.Okul;
            uye.Telefon = p.Telefon;
            uye.Fotograf = p.Fotograf;
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult KitapGecmis(int id)
        {
            var kitapGecmis = db.TblHareket.Where(x => x.Uye == id).ToList();
            var uyeKitap = db.TblUyeler.Where(y => y.ID == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
            ViewBag.u1 = uyeKitap;
            return View(kitapGecmis);
        }

    }
}