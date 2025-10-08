using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Insaat_MVC_WEB.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public  Slider SlidersTakeOne { get; set; }
        public Pages Page { get; set; }
        public IEnumerable<Talent> Talents { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Testimonials> Testimonials { get; set; }
    }
}