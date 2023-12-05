using CV.Web.Models.Entity;
using CV.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Web.Controllers
{
    public class AbaoutController : Controller
    {
        // GET: Abaout
        DbCvEntities2 db = new DbCvEntities2();
        GenericRepository<TblAboutMe> aboutRepository = new GenericRepository<TblAboutMe>();

        [HttpGet]
        public ActionResult Index()
        {
            var about = aboutRepository.List();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(TblAboutMe about)
        {
            var t = aboutRepository.Find(x => x.ID == 1);
            t.Name = about.Name;
            t.Surname = about.Surname;
            t.Adress = about.Adress;
            t.Phone = about.Phone;
            t.Mail = about.Mail;
            t.Description = about.Description;
            t.Image = about.Image;
            aboutRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}