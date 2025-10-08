using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsaatEntityLayer.Entity
{
    public class ProjectImage
    {

        [Key]
        public int ProjectImageID { get; set; }


        [StringLength(255)]
        public string ProjectImageURL { get; set; }



        [StringLength(255)]
        public string ProjectThumbURL { get; set; }


        public int ProjectID { get; set; }
        public Project Project { get; set; }
    }
}
