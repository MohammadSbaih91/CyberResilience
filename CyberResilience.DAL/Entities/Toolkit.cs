namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Toolkits.Toolkits")]
    public partial class Toolkit
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string fileNameAr { get; set; }

        [StringLength(250)]
        public string fileNameEn { get; set; }

        public int ToolkitType { get; set; }

        [StringLength(2)]
        public string attachmentType { get; set; }

        [StringLength(256)]
        public string caption { get; set; }

        [StringLength(100)]
        public string contentType { get; set; }

        public byte[] data { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }

        [StringLength(10)]
        public string CreatedBy { get; set; }

        public virtual Lookup Lookup { get; set; }
    }
}
