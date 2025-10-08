using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsaatEntityLayer.Entity
{
    public class ProjectCategory
    {
        public ProjectCategory()
        {
            Projects = new List<Project>();
        }

        [Key]
        public int ProjectCategoryID { get; set; }

        [StringLength(225)]
        public string ProjectCategoryName { get; set; }


        [StringLength(250)]
        public string ImageURL { get; set; }




        public string MetaDescription { get; set; }


        [StringLength(255)]
        public string MetaKey { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Project> Projects { get; set; }

        public int LangId { get; set; }
        public Lang Langueage { get; set; }
    }
}
