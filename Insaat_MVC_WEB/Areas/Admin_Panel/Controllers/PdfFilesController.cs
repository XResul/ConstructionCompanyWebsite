using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Areas.Admin_Panel.Controllers
{
    public class PdfFilesController : BaseBackEndController
    {
        EntityModelContext db=new EntityModelContext(); 
        // GET: Admin_Panel/PdfFiles
        public ActionResult Index()
        {
            return View(db.pdfFiles.ToList());
        }


        [NonAction]
        public string FileUpload(HttpPostedFileBase file)
        {

            Guid gd = Guid.NewGuid();
            string uzanti = Path.GetExtension(file.FileName);
            file.SaveAs(Server.MapPath("/application/pdf/" + gd.ToString() + "" + uzanti));
            string path = "/application/pdf/" + gd.ToString() + uzanti;

            return path;

        }

        public ActionResult Create()
        {


            return View(new pdfFiles());


        }

        [HttpPost]
        public ActionResult Create(pdfFiles pdf, HttpPostedFileBase file)
        {



            string path = FileUpload(file);

            pdf.FilePath = path;
            db.pdfFiles.Add(pdf);
            if (db.SaveChanges() > 0)
            {

                ViewBag.mesaj = "katalog eklendi";
                return RedirectToAction("index");



            }

            return View(pdf); 
        }



        public ActionResult Delete(int id)
        {
            db.pdfFiles.Remove(db.pdfFiles.Find(id));
            db.SaveChanges();

            return RedirectToAction("index");

        }




    }
}