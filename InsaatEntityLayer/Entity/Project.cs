using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsaatEntityLayer.Entity
{
    public class Project
    {
        public Project()
        {
            ProjectImages = new List<ProjectImage>();
        }

        [Key]
        public int ProjectID { get; set; }

        [StringLength(255)]
        public string ImageURL { get; set; }

        [StringLength(255)]
        public string ThumbURL { get; set; }


        public string MetaDescription { get; set; }


        [StringLength(255)]
        public string MetaKey { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        //ProjectCategory>Project>ProjcetImage
        public int ProjectCategoryID { get; set; }
        public ProjectCategory ProjectCategory { get; set; }



        public ICollection<ProjectImage> ProjectImages { get; set; }

        public int LangId { get; set; }
        public Lang Langueage { get; set; }

    }
}
