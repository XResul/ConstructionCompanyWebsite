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
        //ama burada lang �d y� listelemedik null oldugunda bo� olsun demedik dinm��i mesela bunu nerde kulland�n 
        public int Id { get; set; }

        [StringLength(150)]
        public string TalentTitle { get; set; }

        [StringLength(255)]
        public string MetaDescription { get; set; }

        public int? LangId { get; set; }

        public virtual Lang Lang { get; set; }
    }
}
