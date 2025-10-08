using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Areas.Admin_Panel.Controllers
{
    public class SocialController : BaseBackEndController
    {
        EntityModelContext db =new EntityModelContext();
        // GET: Admin_Panel/Social
        public ActionResult Index()
        {
            return View(db.Social.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Social social)
        {
            if (ModelState.IsValid)
            {
                db.Social.Add(social);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(social);
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Social social = db.Social.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Social social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(social);
        }


        public ActionResult Delete(int id)
        {

            db.Social.Remove(db.Social.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Social social = db.Social.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

    }
}