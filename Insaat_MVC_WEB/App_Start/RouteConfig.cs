using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Insaat_MVC_WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");




            routes.MapRoute(
                name: "DefaultLocalized",
                url: "{lang}/{controller}/{action}/{id}",
                 constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },
                  defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, lang = "tr" }, namespaces: new[] { typeof(Insaat_MVC_WEB.Controllers.HomeController).Namespace }

                );


            routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { typeof(Insaat_MVC_WEB.Controllers.HomeController).Namespace }
    );




        }
    }
}
