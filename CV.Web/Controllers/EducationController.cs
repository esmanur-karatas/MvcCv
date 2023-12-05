using CV.Web.Models.Entity;
using CV.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Web.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<TblMyTrainings> educationRepository=new GenericRepository<TblMyTrainings>();
        public ActionResult Index()
        {
            var education = educationRepository.List();
            return View(education);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(TblMyTrainings tblMyTrainings)
        {
            if(!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            educationRepository.TAdd(tblMyTrainings);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var deleteEducation = educationRepository.Find(x => x.ID == id);
            educationRepository.TRemove(deleteEducation);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var updateEducation=educationRepository.Find(x=>x.ID==id);
            return View(updateEducation);
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblMyTrainings t)
        {
            var updateEducation = educationRepository.Find(x => x.ID == t.ID);
            updateEducation.Title= t.Title;
            updateEducation.Subtitle1= t.Subtitle1;
            updateEducation.Subtitle2= t.Subtitle2;
            updateEducation.Date= t.Date;
            updateEducation.GNO= t.GNO;
            educationRepository.TUpdate(updateEducation);
            return RedirectToAction("Index");
        }
    }
}