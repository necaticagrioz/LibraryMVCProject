using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;

namespace LibraryMVCProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        DBLibraryEntities db = new DBLibraryEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TblUyeler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TblUyeler.Add(p);
            db.SaveChanges();
            return View();

        }
    }
}