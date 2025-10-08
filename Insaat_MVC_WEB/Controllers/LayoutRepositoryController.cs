using Insaat_MVC_WEB.Models;
using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Controllers
{
    public class LayoutRepositoryController : BaseController
    {
        EntityModelContext db = new EntityModelContext();
        // GET: LayoutRepository
        public ActionResult HeadPartial()
        {
            return PartialView("HeadComponentPartial");
        }

        public ActionResult HeaderPartial()
        {
            HeaderViewModel headerModel = new HeaderViewModel();

            headerModel.pageCategories = db.PageCategory.Where(p => p.Status == true).ToList();
            headerModel.pages = db.Pages.Where(p => p.Status == true && p.PageCategory.Status == true && p.LangId == BaseController.langid).ToList();

            headerModel.projectCategories = db.ProjectCategory.Where(p => p.Status == true && p.LangId == BaseController.langid).ToList();
            headerModel.projects = db.Project.Where(p => p.Status == true).ToList();

            headerModel.social = db.Social.Take(1).ToList().FirstOrDefault();
            headerModel.contact = db.Contact.Take(1).ToList().FirstOrDefault();
            headerModel.PdfFiles = db.pdfFiles.Where(p => p.FileName != null).ToList();

            return PartialView("HeaderComponentPartial", headerModel);

        }

        public ActionResult ScriptPartial()
        {
            return PartialView("ScriptComponentPartial");

        }
        public ActionResult FooterPartial()
        {
            FooterViewModel footerModel = new FooterViewModel();
            footerModel.social = db.Social.Take(1).ToList().FirstOrDefault();
            footerModel.contact = db.Contact.Where(c => c.LangId == BaseController.langid).Take(1).ToList().FirstOrDefault();

            if (footerModel.contact == null)
            {
              
                footerModel.contact = db.Contact.Take(1).ToList().FirstOrDefault();
             

            }
   

            footerModel.projects = db.Project.Where(p => p.Status == true && p.LangId == BaseController.langid).Take(6).ToList();


            return PartialView("FooterComponentPartial", footerModel);

        }


    }
}