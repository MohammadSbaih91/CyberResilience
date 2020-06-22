namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServiceRequest
    {
        public int Id { get; set; }

        public int ServiceType { get; set; }

        [MaxLength(50)]
        public byte[] ServiceName { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int ServicePaymentType { get; set; }

        public int ServiceRequestStatus { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Lookup Lookup { get; set; }

        public virtual Lookup Lookup1 { get; set; }

        public virtual Lookup Lookup2 { get; set; }

        public virtual ComplianceResult ComplianceResult { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }
    }
}
