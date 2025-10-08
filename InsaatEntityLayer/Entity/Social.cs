using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsaatEntityLayer.Entity
{
    public class Social
    {
        [Key]
        public int SocialID { get; set; }


        [StringLength(250)]
        public string Youtube { get; set; }



        [StringLength(250)]
        public string Instagram { get; set; }



        [StringLength(250)]
        public string Linkedin { get; set; }


        [StringLength(250)]
        public string Facebook { get; set; }


        [StringLength(250)]
        public string Twitter { get; set; }




    }
}
