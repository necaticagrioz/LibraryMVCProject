using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;
using LibraryMVCProject.Models.Classes;
namespace LibraryMVCProject.Controllers
{
    [AllowAnonymous]
    public class ShowcaseController : Controller
    {
        // GET: Showcase
        DBLibraryEntities db = new DBLibraryEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TblKitap.ToList();
            cs.Deger2 = db.TblHakkimizda.ToList();
            //var deger = db.TblKitap.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TblIletisim t) 
        {
            db.TblIletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}