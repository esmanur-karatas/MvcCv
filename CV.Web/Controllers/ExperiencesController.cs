using CV.Web.Models.Entity;
using CV.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Web.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: Experiences
        ExperiencesRepository experiencesRepository = new ExperiencesRepository();
        public ActionResult Index()
        {
            var value = experiencesRepository.List();
            return View(value);
        }

        [HttpGet]
        public ActionResult ExperiencesAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExperiencesAdd(TblExperiences tblExperiences)
        {
            experiencesRepository.TAdd(tblExperiences);
            return RedirectToAction("Index");
        }
        public ActionResult ExperiencesDelete(int id)
        {
            TblExperiences t = experiencesRepository.Find(x => x.ID == id);
            experiencesRepository.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ExperiencesGet(int id)
        {
            TblExperiences t = experiencesRepository.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult ExperiencesGet(TblExperiences p)
        {
            TblExperiences t = experiencesRepository.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;
            t.Date = p.Date;
            t.Description = p.Description;
            experiencesRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}