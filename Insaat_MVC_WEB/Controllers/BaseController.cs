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
    [LangFilter]
    public class BaseController : Controller
    {

      public static  string defaultLang = "tr";
      public static  int langid = 1;
        public static string RouteValue { get; set; }


        public int Langid { get => langid; set => langid = value; }
        public BaseController()
        {

          

        }



       

     
    }
}