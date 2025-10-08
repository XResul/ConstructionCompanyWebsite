namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
        public int Id { get; set; }

        [StringLength(120)]
        public string SliderTitle { get; set; }

        [StringLength(255)]
        public string ImageURL { get; set; }

        [StringLength(200)]
        public string MetaDescription { get; set; }

        public int? LangId { get; set; }

        public virtual Lang Lang { get; set; }
    }
}
