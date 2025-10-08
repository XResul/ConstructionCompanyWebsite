namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PageCategory")]
    public partial class PageCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PageCategory()
        {
            Pages = new HashSet<Pages>();
            // burda da ayný liste null olmasýn anladým Hocam aynýsýnýn mý yapacagýz Talent da  
        }

        public int Id { get; set; }

        [StringLength(120)]
        public string PageCategoryName { get; set; }

        [StringLength(255)]
        public string ImageURL { get; set; }

        [StringLength(400)]
        public string MetaDescription { get; set; }

        [StringLength(100)]
        public string MetaKey { get; set; }

        public bool? Status { get; set; }

        public int? LangId { get; set; }

        public virtual Lang Lang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pages> Pages { get; set; }
    }
}
