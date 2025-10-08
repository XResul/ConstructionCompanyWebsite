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
    public class PageImageController : BaseBackEndController
    {
        EntityModelContext db = new EntityModelContext();
        // GET: Admin_Panel/PageImage
        public ActionResult Index(int id)
        {
            var resimYakalama = db.PageImage.Where(i => i.PageId == id).ToList();
            return View(resimYakalama);
        }


        [HttpPost]
        public ActionResult AddImage(PageImage imagePage, HttpPostedFileBase image)
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


                imagePage.ImageURL = "/Uploads/image/" + gd.ToString() + uzanti;

                imagePage.ThumbURL = "/Uploads/thumb/" + gd.ToString() + uzanti;
            }
            db.PageImage.Add(imagePage);
            db.SaveChanges();
            return RedirectToAction("Index", "PageImage", new { id = imagePage.PageId });
        }

        public ActionResult Delete(int id)
        {

            
            var yakalama = db.PageImage.Find(id);
        
            int? pageid = yakalama.PageId;
            db.PageImage.Remove(yakalama);
            db.SaveChanges();

            
            return RedirectToAction("index", new {id=pageid } );
        }
    }
}