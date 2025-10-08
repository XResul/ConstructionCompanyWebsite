using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Insaat_MVC_WEB.Models.Entities
{
    public partial class EntityModelContext : DbContext
    {
        public EntityModelContext()
            : base("name=EntityContext")
        {
        }

        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Lang> Lang { get; set; }
        public virtual DbSet<MailSetting> MailSetting { get; set; }
        public virtual DbSet<PageCategory> PageCategory { get; set; }
        public virtual DbSet<PageImage> PageImage { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<pdfFiles> pdfFiles { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectCategory> ProjectCategory { get; set; }
        public virtual DbSet<ProjectImage> ProjectImage { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<Social> Social { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Talent> Talent { get; set; }
        public virtual DbSet<Testimonials> Testimonials { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pages>()
                .HasMany(e => e.PageImage)
                .WithOptional(e => e.Pages)
                .HasForeignKey(e => e.PageId);
        }
    }
}
