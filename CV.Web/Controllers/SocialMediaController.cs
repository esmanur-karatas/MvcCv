using CV.Web.Models.Entity;
using CV.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Web.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<TblSocialMedia> socialMediaRepository = new GenericRepository<TblSocialMedia>();
        //DbCvEntities2 db= new DbCvEntities2();
        public ActionResult Index()
        {
            var data=socialMediaRepository.List();
            return View(data);
        }
        [HttpGet]
        public ActionResult AddSocialMedia() 
        {
        return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia p)
        {
            socialMediaRepository.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var data=socialMediaRepository.Find(x=>x.ID==id);
            return View(data);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia p)
        {
            var data= socialMediaRepository.Find(x=>x.ID == p.ID);
            data.Name = p.Name;
            data.Link = p.Link;
            data.icon = p.icon;
            socialMediaRepository.TUpdate(data);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var social = socialMediaRepository.Find(x => x.ID == id);
            socialMediaRepository.TRemove(social);
            return RedirectToAction("Index");
        }
    }
}