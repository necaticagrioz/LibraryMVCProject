using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;
namespace LibraryMVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var deger = db.TblPersonel.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult PersonelEkle(TblPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TblPersonel.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var person = db.TblPersonel.Find(id);
            db.TblPersonel.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TblPersonel.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(TblPersonel p)
        {
            var prs = db.TblPersonel.Find(p.ID);
            prs.Personel = p.Personel;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}