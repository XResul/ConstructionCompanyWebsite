namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Social")]
    public partial class Social
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Youtube { get; set; }

        [StringLength(255)]
        public string Instagram { get; set; }

        [StringLength(255)]
        public string Linkedin { get; set; }

        [StringLength(255)]
        public string Facebook { get; set; }

        [StringLength(255)]
        public string Twitter { get; set; }
    }
}
