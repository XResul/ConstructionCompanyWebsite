namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class pdfFiles
    {
        public int Id { get; set; }

        [StringLength(80)]
        public string FileName { get; set; }

        [StringLength(400)]
        public string FilePath { get; set; }

        public int? LangId { get; set; }

        public virtual Lang Lang { get; set; }
    }
}
