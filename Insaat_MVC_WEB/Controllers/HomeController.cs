
using Insaat_MVC_WEB.Models;
using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Controllers
{

    public class HomeController : BaseController
    {

        EntityModelContext db = new EntityModelContext();


        public ActionResult Index()
        {

             


            HomeViewModel model = new HomeViewModel();
            model.Sliders = db.Slider.Where(s => s.LangId == BaseController.langid).ToList();
            model.Talents = db.Talent.Where(t => t.LangId == BaseController.langid).ToList();
            model.Testimonials = db.Testimonials.ToList();



            if (BaseController.langid == 1)
            {
                model.Page = db.Pages.Where(p => p.Id == 1 && p.Status == true && p.LangId == BaseController.langid).FirstOrDefault();

            }
            else
            {
                model.Page = db.Pages.Where(p => p.Id == 3 && p.Status == true && p.LangId == BaseController.langid).FirstOrDefault();
            }






            model.Projects = db.Project.Where(p => p.Status == true && p.LangId == BaseController.langid).Take(6).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult HeroPartial()
        {
            HomeViewModel sliderS = new HomeViewModel();
            sliderS.Sliders = db.Slider.ToList();
            return PartialView("HeroPartial", sliderS);

        }

        public ActionResult AboutWePartial()
        {
            HomeViewModel pageModel = new HomeViewModel();

            if (BaseController.langid == 1)
            {
                pageModel.Page = db.Pages.Where(p => p.Id == 1 && p.Status == true && p.LangId == BaseController.langid).FirstOrDefault();

            }
            else
            {
                pageModel.Page = db.Pages.Where(p => p.Id == 3 && p.Status == true && p.LangId == BaseController.langid).FirstOrDefault();
            }


            return PartialView("AboutWePartial", pageModel);

        }
        public ActionResult TalentsPartial()
        {
            HomeViewModel talentsModel = new HomeViewModel();
            talentsModel.Talents = db.Talent.Where(t => t.LangId == BaseController.langid).ToList();

      return PartialView("TalentsPartial", talentsModel);
        }

        public ActionResult ProjectHomePartial()
        {
            HomeViewModel projectModel = new HomeViewModel();
            projectModel.Projects = db.Project.Where(p => p.Status == true && p.LangId == BaseController.langid).Take(6).ToList();
            return PartialView("ProjectHomePartial", projectModel);

        }

        public ActionResult TestimonialsPartial()
        {
            HomeViewModel testimonialsModel = new HomeViewModel();
            testimonialsModel.Testimonials = db.Testimonials.Where(t => t.LangId == BaseController.langid).ToList();
            return PartialView("TestimonialsPartial", testimonialsModel);

        }


    }
}