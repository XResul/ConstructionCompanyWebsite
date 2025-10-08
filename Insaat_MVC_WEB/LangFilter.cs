using Insaat_MVC_WEB.Controllers;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

using System.Web.Mvc;
using System.Web.Routing;

namespace Insaat_MVC_WEB
{
    public class LangFilter :System.Web.Mvc.FilterAttribute,System.Web.Mvc.IActionFilter
    {
        string defaultLang = "tr";
        int langid = 1;

        public int Langid { get => langid; set => langid = value; }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {


            if (filterContext.RouteData.Values["lang"] == null || filterContext.RouteData.Values["lang"].ToString() == "tr")
            {




                defaultLang = "tr";

                string culture = defaultLang;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                BaseController.langid = 1;
                filterContext.RequestContext.RouteData.Values["lang"] = "tr";
                BaseController.RouteValue = "/tr";
            }
          
            else
            {


                defaultLang = filterContext.RouteData.Values["lang"].ToString();



                string culture = defaultLang;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                BaseController.langid = 2;
                BaseController.RouteValue = "/en";


                filterContext.RequestContext.RouteData.Values["lang"] = "en";



            }
        }

      
    }
}