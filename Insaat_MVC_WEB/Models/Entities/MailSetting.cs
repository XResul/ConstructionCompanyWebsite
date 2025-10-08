namespace Insaat_MVC_WEB.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MailSetting")]
    public partial class MailSetting
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string SenderEmail { get; set; }

        [StringLength(150)]
        public string SenderPassword { get; set; }

        public int Port { get; set; }

        public bool EnableSsl { get; set; }

        [StringLength(150)]
        public string ReceiverMail { get; set; }

        public string Smtp { get; set; }
    }
}
