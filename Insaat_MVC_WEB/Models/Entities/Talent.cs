namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Talent")]
    public partial class Talent
    {
        //ama burada lang ýd yý listelemedik null oldugunda boþ olsun demedik dinmöçi mesela bunu nerde kullandýn 
        public int Id { get; set; }

        [StringLength(150)]
        public string TalentTitle { get; set; }

        [StringLength(255)]
        public string MetaDescription { get; set; }

        public int? LangId { get; set; }

        public virtual Lang Lang { get; set; }
    }
}
