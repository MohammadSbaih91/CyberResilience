namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ServiceRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceRequest()
        {
            ComplianceResults = new HashSet<ComplianceResult>();
            QuestionsAssessmentDetails = new HashSet<QuestionsAssessmentDetail>();
        }

        public int Id { get; set; }

        public int ServiceType { get; set; }

        public string ServiceName { get; set; }

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

        public int? ServiceSubType { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Lookup Lookup { get; set; }

        public virtual Lookup Lookup1 { get; set; }

        public virtual Lookup Lookup2 { get; set; }

        public virtual Lookup Lookup3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComplianceResult> ComplianceResults { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionsAssessmentDetail> QuestionsAssessmentDetails { get; set; }
    }
}
