using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsaatEntityLayer.Entity
{
    public class Talent
    {
        [Key]
        public int TalentID { get; set; }

        [StringLength(125)]
        public string TalentTitle { get; set; }


        [StringLength(500)]
        public string MetaDescription { get; set; }

        public int LangId { get; set; }
        public Lang Lang { get; set; }
    }
}
