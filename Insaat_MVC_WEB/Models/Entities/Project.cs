namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            ProjectImage = new HashSet<ProjectImage>();
            // mesela bu niye yazýlmýþ 
            //projeye ait resimleri listelemek için
            // hayýr projectimage listesi null olmasýn onun yerine boþ bir liste gelsinki null olupta hataya sebep olmasýn
        }

        public int Id { get; set; }

        [StringLength(225)]
        public string ProjectName { get; set; }

        [StringLength(255)]
        public string ImageURL { get; set; }

        [StringLength(255)]
        public string ThumbURL { get; set; }

        public string MetaDescription { get; set; }

        [StringLength(225)]
        public string MetaKey { get; set; }

        public string Description { get; set; }

        public bool? Status { get; set; }

        public int? ProjectCategoryId { get; set; }

        public int? LangId { get; set; }

        public virtual Lang Lang { get; set; }

        public virtual ProjectCategory ProjectCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectImage> ProjectImage { get; set; }
    }
}
