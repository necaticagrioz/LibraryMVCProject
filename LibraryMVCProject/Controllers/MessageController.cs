using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;
namespace LibraryMVCProject.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var uyeMail = (string)Session["Mail"].ToString();
            var mesaj = db.TblMesaj.Where(x => x.Alici == uyeMail.ToString()).ToList();
            return View(mesaj);
        }
        public ActionResult Giden()
        {
            var uyeMail = (string)Session["Mail"].ToString();
            var mesaj = db.TblMesaj.Where(x => x.Gonderen == uyeMail.ToString()).ToList();
            return View(mesaj);
        }
        [HttpGet]
        public ActionResult YeniMesaj() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TblMesaj t)
        {
            var uyeMail = (string)Session["Mail"].ToString();
            t.Gonderen = uyeMail.ToString();
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString()); 
            db.TblMesaj.Add(t);
            db.SaveChanges();
            return RedirectToAction("Giden","Message");
        }
        public PartialViewResult Partial1()
        {
            var uyeMail = (string)Session["Mail"].ToString();
            var gelenSayisi = db.TblMesaj.Where(x => x.Alici == uyeMail).Count();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = db.TblMesaj.Where(x => x.Gonderen == uyeMail).Count();
            ViewBag.d2 = gidenSayisi;
            return PartialView();
        }
    }
}