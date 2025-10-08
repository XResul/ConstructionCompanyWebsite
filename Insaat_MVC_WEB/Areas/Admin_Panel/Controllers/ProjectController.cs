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
    public class ProjectController : BaseBackEndController
    {
        EntityModelContext db = new EntityModelContext();
        // GET: Admin_Panel/Project
        public ActionResult Index()
        {
            var project = db.Project.Include(p => p.ProjectCategory);
            return View(project.ToList());
        }



        public ActionResult Create()
        {
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");
            ViewBag.ProjectCategoryId = new SelectList(db.ProjectCategory, "Id", "Categoryname");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Project project, HttpPostedFileBase image)
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


                    project.ImageURL = "/Uploads/image/" + gd.ToString() + uzanti;
                    project.ThumbURL = "/Uploads/thumb/" + gd.ToString() + uzanti;
                }
                db.Project.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageCategoryID = new SelectList(db.PageCategory, "Id", "Categoryname", project.ProjectCategoryId);

            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", project.LangId);

           
            return View(project);

        }






        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Project project = db.Project.Find(id);
            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name");

            ViewBag.ProjectCategoryId = new SelectList(db.ProjectCategory, "Id", "Categoryname");
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Project project, HttpPostedFileBase image)
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


                    project.ImageURL = "/Uploads/image/" + gd.ToString() + uzanti;
                }
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PageCategoryID = new SelectList(db.PageCategory, "Id", "Categoryname", project.ProjectCategoryId);

            ViewBag.LangId = new SelectList(db.Lang, "Id", "Name", project.LangId);

            return View(project);

        }



        public ActionResult pasifYap(int id)
        {
            Project project = db.Project.Find(id);
            project.Status = false;
            db.Entry(project).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult aktifYap(int id)
        {
            Project project = db.Project.Find(id);
            project.Status = true;
            db.Entry(project).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Project project = db.Project.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);

        }


    }
}