using CV.Web.Models.Entity;
using CV.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<TblCommunication> contactRepository = new GenericRepository<TblCommunication>();
        public ActionResult Index()
        {
            var contact=contactRepository.List();
            return View(contact);
        }
        public ActionResult DeleteContact(int id)
        {
            var deleteContact = contactRepository.Find(x => x.ID == id);
            contactRepository.TRemove(deleteContact);
            return RedirectToAction("Index");
        }
    }

}