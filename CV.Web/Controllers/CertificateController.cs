using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV.Web.Models.Entity;
using CV.Web.Repositories;

namespace CV.Web.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        GenericRepository<TblCertificate> certificateRepository=new GenericRepository<TblCertificate>();
        public ActionResult Index()
        {
            var certificate = certificateRepository.List();
            return View(certificate);
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(TblCertificate t)
        {
            certificateRepository.TAdd(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCertificate(int id) 
        {
            var certificate = certificateRepository.Find(x => x.ID == id);
            return View(certificate);
        }

        [HttpPost]
        public ActionResult UpdateCertificate(TblCertificate t)
        {
            var certificate=certificateRepository.Find(x=>x.ID==t.ID);
            certificate.Title = t.Title;
            certificate.Description = t.Description;
            certificate.Date = t.Date;
            certificateRepository.TUpdate(certificate);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertificate(int id)
        {
            var certificate = certificateRepository.Find(x => x.ID == id);
            certificateRepository.TRemove(certificate);
            return RedirectToAction("Index");
        }
    }
}