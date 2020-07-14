namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Standard
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string StandardNameEn { get; set; }

        public string StandardNameAr { get; set; }

        public int? StandardNumber { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }

        public int? StandardTypeId { get; set; }

        public virtual Lookup Lookup { get; set; }
    }
}
