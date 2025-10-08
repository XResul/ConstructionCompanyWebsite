using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insaat_MVC_WEB.Models
{
    public class ProjectViewModel
    {


        public IEnumerable<Project> projects { get; set; }
        public IEnumerable<ProjectImage> projectImages { get; set; }

        public ProjectCategory projectCategory { get; set; }
        public Project  projectTakeOne { get; set; }



    }
}