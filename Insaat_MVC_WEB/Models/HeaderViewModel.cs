using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insaat_MVC_WEB.Models
{
    public class HeaderViewModel
    {
        public IEnumerable<PageCategory> pageCategories { get; set; }
        public IEnumerable<Pages> pages { get; set; }



        public IEnumerable<ProjectCategory> projectCategories { get; set; }
        public IEnumerable<Project> projects { get; set; }



        public IEnumerable<pdfFiles> PdfFiles { get; set; }

        //public  pdfFiles  PdfFilesTakeOne { get; set; }
        
        
        public Contact contact { get; set; }
        public Social social { get; set; }

    }
}