using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Areas.Admin_Panel.Controllers
{
    public class PagesController : BaseBackEndController
    {
        EntityModelContext db =new EntityModelContext();
        // GET: Admin_Panel/Pages
        public ActionResult Index()
        {
            var page = db.Pages.Include(p=>p.PageCategory).ToList();
            return View(page);
        }


        public ActionResult Create()
        {
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            ViewBag.PageCategoryID = new SelectList(db.PageCategory, "Id", "PageCategoryname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Pages page, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    WebLibrary.GraphicClass.ImageResizer ir = new WebLibrary.GraphicClass.ImageResizer();
                    Image img = Image.FromStream(image.InputStream);
                    string uzanti = Path.GetExtension(image.FileName);
                    Guid gd = Guid.NewGuid();

                    List<Image> images = ir.Resize(img, 800, 350);

                    ir.saveJpeg(Server.MapPath("/Uploads/image/" + gd.ToString() + uzanti), images[0], 100);
                    ir.saveJpeg(Server.MapPath("/Uploads/thumb/" + gd.ToString() + uzanti), images[1], 100);


                    page.ImageURL = "/Uploads/image/" + gd.ToString() + uzanti;
                    page.ThumbURL = "/Uploads/thumb/" + gd.ToString() + uzanti;
                }
                db.Pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageCategoryID = new SelectList(db.PageCategory, "Id", "PageCategoryname", page.PageCategoryId);
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", page.LangId);
            return View(page);
        }





        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Pages emlak = db.Pages.Find(id);
            ViewBag.PageCategoryID = new SelectList(db.PageCategory, "Id", "PageCategoryname");
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(emlak);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Pages page, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    WebLibrary.GraphicClass.ImageResizer ir = new WebLibrary.GraphicClass.ImageResizer();
                    Image img = Image.FromStream(image.InputStream);
                    string uzanti = Path.GetExtension(image.FileName);
                    Guid gd = Guid.NewGuid();

                    List<Image> images = ir.Resize(img, 800, 350);

                    ir.saveJpeg(Server.MapPath("/Uploads/image/" + gd.ToString() + uzanti), images[0], 100);
                    ir.saveJpeg(Server.MapPath("/Uploads/thumb/" + gd.ToString() + uzanti), images[1], 100);


                    page.ImageURL = "/Uploads/image/" + gd.ToString() + uzanti;
                    page.ThumbURL = "/Uploads/thumb/" + gd.ToString() + uzanti;
                }
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageCategoryID = new SelectList(db.PageCategory, "Id", "PageCategoryname", page.PageCategoryId);
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", page.LangId);
            return View(page);
        }



        public ActionResult pasifYap(int id)
        {
            Pages pages = db.Pages.Find(id);
            pages.Status = false;
            db.Entry(pages).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult aktifYap(int id)
        {
            Pages pages = db.Pages.Find(id);
            pages.Status = true;
            db.Entry(pages).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Pages page = db.Pages.Find(id); 
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);

        }


    }
}