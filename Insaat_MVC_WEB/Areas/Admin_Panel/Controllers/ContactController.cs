using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Areas.Admin_Panel.Controllers
{
    public class ContactController : BaseBackEndController
    {
        EntityModelContext db = new EntityModelContext();
        // GET: Admin_Panel/Contact
        public ActionResult Index()
        {
            return View(db.Contact.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {

            if (ModelState.IsValid)
            {
                db.Contact.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", contact.LangId);
            return View(contact);
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Contact contact = db.Contact.Find(id);
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", contact.LangId);
            return View(contact);
        }



        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Contact contact = db.Contact.Find(id);
          
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        public ActionResult Delete(int id)
        {
            if (id ==3)
            {
                return HttpNotFound();

            }
            else 
            {

                db.Contact.Remove(db.Contact.Find(id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
       
        }




    }
}