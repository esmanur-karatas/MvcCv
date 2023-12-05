using CV.Web.Models.Entity;
using CV.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> adminRepository=new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var admin=adminRepository.List();
            return View(admin);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(TblAdmin tblExperiences)
        {
            adminRepository.TAdd(tblExperiences);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            TblAdmin t = adminRepository.Find(x => x.ID == id);
            adminRepository.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            TblAdmin t = adminRepository.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(TblAdmin p)
        {
            TblAdmin t = adminRepository.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.UserName = p.UserName;
            t.Password = p.Password;
            adminRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
