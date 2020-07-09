namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Templates.Attachments")]
    public partial class Attachment
    {
        public int AttachmentID { get; set; }

        [StringLength(2)]
        public string attachmentType { get; set; }

        [Required]
        [StringLength(256)]
        public string fileName { get; set; }

        [StringLength(256)]
        public string caption { get; set; }

        [StringLength(100)]
        public string contentType { get; set; }

        public byte[] data { get; set; }

        public int TemplateID { get; set; }

        public virtual Template Template { get; set; }
    }
}
