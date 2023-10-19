using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVCProject.Models.Entity;
namespace LibraryMVCProject.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        DBLibraryEntities db = new DBLibraryEntities();
        public ActionResult Index()
        {
            var deger = db.TblHareket.Where(x=>x.IslemDurum == true).ToList();
            return View(deger);
        }
    }
}