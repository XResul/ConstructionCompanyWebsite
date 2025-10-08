using Insaat_MVC_WEB.Models;
using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Controllers
{
    public class PdfFilesController : Controller
    {
        EntityModelContext db = new EntityModelContext();
        // GET: PdfFiles
        public ActionResult Index(int id)
        {
            pdfFiles pdfFiles = db.pdfFiles.Find(id);
            PdfFilesViewModel modelPDF = new PdfFilesViewModel();
            modelPDF.pdfFilesTakeOne = db.pdfFiles.Where(p => p.Id == id).Take(1).FirstOrDefault();

            return View(modelPDF);
        }
    }
}