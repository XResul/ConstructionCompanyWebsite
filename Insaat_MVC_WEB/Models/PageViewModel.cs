using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insaat_MVC_WEB.Models
{
    public class PageViewModel
    {
        public Pages Pagess { get; set; }
        public IEnumerable<PageImage> PageImages { get; set; }

    }
}