using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV.Web.Models.Entity;
using CV.Web.Repositories;
namespace CV.Web.Controllers
{
    public class SkilssController : Controller
    {
        // GET: Skilss
        GenericRepository<TblSkills> skillsRepository = new GenericRepository<TblSkills>();
        public ActionResult Index()
        {
            var skills = skillsRepository.List();
            return View(skills);
        }

        [HttpGet]
        public ActionResult NewSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSkill(TblSkills skills)
        {
            skillsRepository.TAdd(skills);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            TblSkills skill = skillsRepository.Find(x => x.ID == id);
            skillsRepository.TRemove(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            TblSkills t = skillsRepository.Find(x => x.ID == id);
            return View(t);

        }

        [HttpPost]
        public ActionResult EditSkill(TblSkills p)
        {
            TblSkills t = skillsRepository.Find(x => x.ID == p.ID);
            t.Skill = p.Skill;
            skillsRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}