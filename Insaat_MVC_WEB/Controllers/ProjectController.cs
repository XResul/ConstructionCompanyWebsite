using Insaat_MVC_WEB.Models;
using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Controllers
{
    public class ProjectController : BaseController
    {
        EntityModelContext db = new EntityModelContext();

        // GET: Project
        public ActionResult Index(int id)
        {
            ProjectViewModel model = new ProjectViewModel(); 
     

        
           
                model.projects = db.Project.Where(p => p.ProjectCategoryId == id && p.Status == true && p.LangId == BaseController.langid).ToList();
                model.projectCategory = db.ProjectCategory.Where(p => p.Id == id && p.LangId == BaseController.langid).FirstOrDefault();
                return View(model);
            
             
        }



        public ActionResult projectDetail(int id)
        {

          var lng=  RouteData.Values["lang"].ToString() ;
            Project projectFind = db.Project.Find(id);
            ProjectViewModel model = new ProjectViewModel();

            model.projectImages = db.ProjectImage.Where(i => i.ProjectId == projectFind.Id).ToList();

            model.projectTakeOne = projectFind;
            model.projectCategory = db.ProjectCategory.Where(p => p.Id == projectFind.ProjectCategoryId).FirstOrDefault();

            return View(model);
        }



    }
}