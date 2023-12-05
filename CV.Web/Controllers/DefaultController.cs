using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV.Web.Models.Entity;

namespace CV.Web.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities2 db= new DbCvEntities2();
        public ActionResult Index()
        {
            var values = db.TblAboutMe.ToList();
            return View(values);
        }
        public PartialViewResult SocialMedia()
        {
            var socialMedia = db.TblSocialMedia.ToList();
            return PartialView(socialMedia);
        }
        public PartialViewResult Experiences()
        {
            var experiences= db.TblExperiences.ToList();
            return PartialView(experiences);
        }  
        public PartialViewResult Trainings()
        {
            var trainings= db.TblMyTrainings.ToList();
            return PartialView(trainings);
        }
        public PartialViewResult Skills()
        {
            var skills = db.TblSkills.ToList();
            return PartialView(skills);
        }

        public PartialViewResult Certificate()
        {
            var certificate= db.TblCertificate.ToList();
            return PartialView(certificate);
        }
        [HttpGet]
        public PartialViewResult Contact() => PartialView();
        [HttpPost]
        public PartialViewResult Contact(TblCommunication t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblCommunication.Add(t);
            db.SaveChanges();
            return PartialView();
        }
        
       

    }
}