using Insaat_MVC_WEB.Models;
using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Controllers
{
    public class PageController : Controller
    {
        EntityModelContext db = new EntityModelContext();
        // GET: Page
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult pageDetail(int id)
        {
            PageViewModel model = new PageViewModel();
            model.Pagess = db.Pages.Where(p => p.Id == id && p.LangId==BaseController.langid).FirstOrDefault();
            model.PageImages = db.PageImage.Where(i => i.PageId == id).ToList();
   
            return View(model);

        }
    }
}