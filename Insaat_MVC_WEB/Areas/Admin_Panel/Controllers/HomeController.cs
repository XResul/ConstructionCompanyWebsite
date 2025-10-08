using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insaat_MVC_WEB.Areas.Admin_Panel.Controllers
{
    public class HomeController : BaseBackEndController
    {
        // GET: Admin_Panel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}