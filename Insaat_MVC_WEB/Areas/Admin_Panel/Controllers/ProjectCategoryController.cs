using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Areas.Admin_Panel.Controllers
{
    public class ProjectCategoryController : BaseBackEndController
    {
        EntityModelContext db =new EntityModelContext();
        // GET: Admin_Panel/ProjectCategory
        public ActionResult Index()
        {
            return View(db.ProjectCategory.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCategory category, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    Image img = Image.FromStream(image.InputStream);

                    Guid gd = Guid.NewGuid();
                    string uzanti = Path.GetExtension(image.FileName);

                    WebLibrary.GraphicClass.ImageResizer ir = new WebLibrary.GraphicClass.ImageResizer();

                    List<Image> lstimage = ir.Resize(img, 800, 350);

                    ir.saveJpeg(Server.MapPath("/Uploads/image/" + gd.ToString() + uzanti), lstimage[0], 100);

                    category.ImageURL = "/Uploads/image/" + gd.ToString() + uzanti;

                }
                db.ProjectCategory.Add(category);
                db.SaveChanges();
                ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", category.LangId);
                return RedirectToAction("Index");
            }
            return View(category);
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ProjectCategory category = db.ProjectCategory.Find(id);
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectCategory category, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    Image img = Image.FromStream(image.InputStream);

                    Guid gd = Guid.NewGuid();
                    string uzanti = Path.GetExtension(image.FileName);

                    WebLibrary.GraphicClass.ImageResizer ir = new WebLibrary.GraphicClass.ImageResizer();

                    List<Image> lstimage = ir.Resize(img, 800, 350);

                    ir.saveJpeg(Server.MapPath("/Uploads/image/" + gd.ToString() + uzanti), lstimage[0], 100);

                    category.ImageURL = "/Uploads/image/" + gd.ToString() + uzanti;

                }
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", category.LangId);
                return RedirectToAction("Index");
            }
            return View(category);
        }


        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ProjectCategory category = db.ProjectCategory.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);

        }


        public ActionResult pasifYap(int id)
        {
            ProjectCategory category = db.ProjectCategory.Find(id);
            category.Status = false;
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult aktifYap(int id)
        {
            ProjectCategory category = db.ProjectCategory.Find(id);
            category.Status = true;
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}