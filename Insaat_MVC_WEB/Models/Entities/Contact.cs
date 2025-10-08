namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(40)]
        public string Phone { get; set; }

        [StringLength(40)]
        public string Whatsapp { get; set; }

        [StringLength(120)]
        public string Email { get; set; }

        public string Adres { get; set; }

        public string Map { get; set; }

        public int? LangId { get; set; }

        public virtual Lang Lang { get; set; }
    }
}
