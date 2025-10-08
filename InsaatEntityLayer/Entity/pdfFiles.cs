using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsaatEntityLayer.Entity
{
    public class pdfFiles
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }


        public string FilePath { get; set; }

        public int LangId { get; set; }
        public Lang Langueage { get; set; }
    }
}
