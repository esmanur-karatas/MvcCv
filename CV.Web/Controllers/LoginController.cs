using CV.Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CV.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities2 db = new DbCvEntities2();
            var userInfo = db.TblAdmin.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (userInfo !=null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
                Session["UserName"] = userInfo.UserName.ToString();
                return RedirectToAction("Index", "Experiences");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}