using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsaatEntityLayer.Entity
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }


        [StringLength(70)]
        public string UserName { get; set; }


        [StringLength(70)]
        public string UserPassword { get; set; }

        [StringLength(90)]
        public string Email { get; set; }

        [StringLength(1)]
        public string Role { get; set; }

    }
}
