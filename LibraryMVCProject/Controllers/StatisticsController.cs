using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;
namespace LibraryMVCProject.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var deger1 = db.TblUyeler.Count();
            var deger2 = db.TblKitap.Count();
            var deger3 = db.TblKitap.Where(x=>x.Durum == false).Count();
            var deger4 = db.TblCeza.Sum(x => x.Para);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Weather() 
        {
            return View();
        }
        public ActionResult WeatherCard()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PhotoUpload(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayol = Path.Combine(Server.MapPath("~/web2/Photos/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayol);
            }
            return RedirectToAction("Gallery");
        }
    }
}