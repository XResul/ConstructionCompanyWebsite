namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectImage")]
    public partial class ProjectImage
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string ImageURL { get; set; }

        [StringLength(255)]
        public string ThumbURL { get; set; }

        public int? ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
