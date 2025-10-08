using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InsaatEntityLayer.Entity
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }


        [StringLength(150)]
        public string ContactTitle { get; set; }


        [StringLength(40)]
        public string Phone { get; set; }


        [StringLength(40)]
        public string Whatsapp { get; set; }



        [StringLength(120)]
        public string Email { get; set; }

        public string Adres { get; set; }


        [AllowHtml]
        public string Map { get; set; }

        public int LangId { get; set; }
        public Lang Langueage { get; set; }

    }
}
