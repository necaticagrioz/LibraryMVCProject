using LibraryMVCProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryMVCProject.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        // GET: Panel
        DBLibraryEntities db = new DBLibraryEntities();
        [HttpGet]
        
        public ActionResult Index()
        {
            var uyeMail = (string)Session["Mail"];
            //var deger = db.TblUyeler.FirstOrDefault(x=>x.Mail == uyeMail);
            var deger = db.TblDuyuru.ToList();
            var d1 = db.TblUyeler.Where(x => x.Mail == uyeMail).Select(y => y.Ad).FirstOrDefault();
            var d2 = db.TblUyeler.Where(x => x.Mail == uyeMail).Select(y => y.Soyad).FirstOrDefault();
            var d3 = db.TblUyeler.Where(x => x.Mail == uyeMail).Select(y => y.Fotograf).FirstOrDefault();
            var d4 = db.TblUyeler.Where(x => x.Mail == uyeMail).Select(y => y.KullaniciAdi).FirstOrDefault();
            var d5 = db.TblUyeler.Where(x => x.Mail == uyeMail).Select(y => y.Okul).FirstOrDefault();
            var d6 = db.TblUyeler.Where(x => x.Mail == uyeMail).Select(y => y.Telefon).FirstOrDefault();
            var d7 = db.TblUyeler.Where(x => x.Mail == uyeMail).Select(y => y.Mail).FirstOrDefault();
            var uyeId = db.TblUyeler.Where(x => x.Mail == uyeMail).Select(y => y.ID).FirstOrDefault();
            var d8 = db.TblHareket.Where(x => x.Uye == uyeId).Count();
            var d9 = db.TblMesaj.Where(x => x.Alici == uyeMail).Count();
            

            ViewBag.d1 = d1;
            ViewBag.d2 = d2;
            ViewBag.d3 = d3;
            ViewBag.d4 = d4;
            ViewBag.d5 = d5;
            ViewBag.d6 = d6;
            ViewBag.d7 = d7;
            ViewBag.d8 = d8;
            ViewBag.d9 = d9;
            return View(deger);
        }
        [HttpPost]
        public ActionResult Index2(TblUyeler p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TblUyeler.FirstOrDefault(x => x.Mail == kullanici);
            uye.Sifre= p.Sifre;
            uye.Ad = p.Ad;
            uye.Soyad = p.Soyad;
            uye.Mail = p.Mail;
            uye.KullaniciAdi = p.KullaniciAdi;
            uye.Sifre = p.Sifre;
            uye.Fotograf = p.Fotograf;
            uye.Telefon = p.Telefon;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TblUyeler.Where(x=>x.Mail == kullanici.ToString()).Select(z=>z.ID).FirstOrDefault();
            var deger = db.TblHareket.Where(x=> x.Uye ==id).ToList();
            return View(deger);
        }
        public ActionResult Duyurular()
        {
            var duyuruListe = db.TblDuyuru.ToList();
            return View(duyuruListe);
        }
        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TblUyeler.Where(x => x.Mail == kullanici).Select(y => y.ID).FirstOrDefault();
            var uyeGetir = db.TblUyeler.Find(id);
            return PartialView("Partial2",uyeGetir);
        }
    }
}