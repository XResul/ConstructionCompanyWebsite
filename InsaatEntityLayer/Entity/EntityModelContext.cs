using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsaatEntityLayer.Entity
{
    public class EntityModelContext:DbContext
    {
        public EntityModelContext() : base("name=sqlcon")
        {
        }


        public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Page> Pages { get; set; }
        //public DbSet<PageCategory>  PageCategories { get; set; }
        //public DbSet<PageImage>  PageImages { get; set; }
        public DbSet<pdfFiles>  PdfFiles { get; set; }
        public DbSet<Slider>  Sliders { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Users>  Users { get; set; }
        public DbSet<VideoURL>  VideoURL { get; set; }
    
    
    
    
        public DbSet<ProjectCategory>  ProjectCategories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage>  ProjectImages { get; set; }

        public DbSet<Lang>  Langs { get; set; }

        public DbSet<Talent>  Talents { get; set; }

        public DbSet<Testimonials>   Testimonials { get; set; }




    }
}
