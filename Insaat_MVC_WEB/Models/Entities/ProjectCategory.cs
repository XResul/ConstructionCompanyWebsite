namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectCategory")]
    public partial class ProjectCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectCategory()
        {
            Project = new HashSet<Project>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }

        [StringLength(250)]
        public string ImageURL { get; set; }

        public string MetaDescription { get; set; }

        [StringLength(225)]
        public string MetaKey { get; set; }

        public bool? Status { get; set; }

        public int? LangId { get; set; }

        public virtual Lang Lang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project { get; set; }
    }
}
