using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Areas.Admin_Panel.Controllers
{
    public class TalentsController : BaseBackEndController
    {
        EntityModelContext db = new EntityModelContext();
        // GET: Admin_Panel/Talents
        public ActionResult Index()
        {
            return View(db.Talent.ToList());
        }


        public ActionResult Create()
        {
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Talent talent)
        {

            if (ModelState.IsValid)
            {
                db.Talent.Add(talent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", talent.LangId);
            return View(talent);
        }





        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Talent talent = db.Talent.Find(id);
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            if (talent == null)
            {
                return HttpNotFound();
            }
            return View(talent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Talent talent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talent).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", talent.LangId);
            return View(talent);
        }





        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Talent talent = db.Talent.Find(id);
            if (talent == null)
            {
                return HttpNotFound();
            }
            return View(talent);
        }

        public ActionResult Delete(int id)
        {
            db.Talent.Remove(db.Talent.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
