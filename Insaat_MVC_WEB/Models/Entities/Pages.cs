namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pages
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pages()
        {
            PageImage = new HashSet<PageImage>();
        }

        public int Id { get; set; }

        [StringLength(120)]
        public string PageName { get; set; }

        [StringLength(255)]
        public string ImageURL { get; set; }

        [StringLength(255)]
        public string ThumbURL { get; set; }

        [StringLength(500)]
        public string MetaDescription { get; set; }

        [StringLength(100)]
        public string MetaKey { get; set; }

        public string Description { get; set; }

        public bool? Status { get; set; }

        public int? PageCategoryId { get; set; }

        public int? LangId { get; set; }

        public virtual Lang Lang { get; set; }

        public virtual PageCategory PageCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PageImage> PageImage { get; set; }
    }
}
