using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Areas.Admin_Panel.Controllers
{
    public class TestimonialsController : BaseBackEndController
    {
        EntityModelContext db = new EntityModelContext();
        // GET: Admin_Panel/Testimonials
        public ActionResult Index()
        {
            return View(db.Testimonials.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Testimonials testimonials)
        {

            if (ModelState.IsValid)
            {
                db.Testimonials.Add(testimonials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", testimonials.LangId);
            return View(testimonials);
        }






        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Testimonials testimonials = db.Testimonials.Find(id);
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            if (testimonials == null)
            {
                return HttpNotFound();
            }
            return View(testimonials);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Testimonials testimonials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testimonials).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", testimonials.LangId);
            return View(testimonials);
        }





        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Testimonials testimonials = db.Testimonials.Find(id);
            if (testimonials == null)
            {
                return HttpNotFound();
            }
            return View(testimonials);
        }

        public ActionResult Delete(int id)
        {
            db.Testimonials.Remove(db.Testimonials.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}