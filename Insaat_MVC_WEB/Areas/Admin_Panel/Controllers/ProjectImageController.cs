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
    public class ProjectImageController : BaseBackEndController
    {
        EntityModelContext db =new EntityModelContext(); 
        // GET: Admin_Panel/ProjectImage
        public ActionResult Index(int id)
        {
            var resimYakalama = db.ProjectImage.Where(i => i.ProjectId == id).ToList();
            return View(resimYakalama);
        }



        [HttpPost]
        public ActionResult AddImage(ProjectImage imageProject, HttpPostedFileBase image)
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


                imageProject.ImageURL = "/Uploads/image/" + gd.ToString() + uzanti;

                imageProject.ThumbURL = "/Uploads/thumb/" + gd.ToString() + uzanti;
            }
            db.ProjectImage.Add(imageProject);
            db.SaveChanges();
            return RedirectToAction("index", "ProjectImage", new { id = imageProject.ProjectId });
        }


        public ActionResult Delete(int id)
        {
            var yakalama = db.ProjectImage.Find(id);
            int? projectid=yakalama.ProjectId;

            db.ProjectImage.Remove(yakalama);
            db.SaveChanges();
            return RedirectToAction("index", new {id=projectid });

        }
    }
}