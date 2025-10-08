using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsaatEntityLayer.Entity
{
    public class VideoURL
    {
        [Key]
        public int VideoUrlID { get; set; }

        [StringLength(120)]
        public string videoUrlTitle { get; set; }


        public string VideoURL_ { get; set; }

        public int LangId { get; set; }
        public Lang Lang { get; set; }
    }
}
