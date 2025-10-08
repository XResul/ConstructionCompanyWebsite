using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insaat_MVC_WEB.Models
{
    public class FooterViewModel
    {

        public Social social { get; set; }
        public Contact contact { get; set; }

        public IEnumerable<Project> projects { get; set; }

    }
}