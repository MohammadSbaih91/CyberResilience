namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceRequests.ComplianceResults")]
    public partial class ComplianceResult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComplianceResult()
        {
            QuestionsAssessmentDetails = new HashSet<QuestionsAssessmentDetail>();
        }

        public int Id { get; set; }

        public double QuestionnaireAccurateComplianceResult { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }

        public bool? IsArchived { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IsUpdated { get; set; }

        public int? ImplementationPeriodTime { get; set; }

        public DateTime? ImplementationPeriodAccurateExpectedTime { get; set; }

        public int ServiceRequestId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionsAssessmentDetail> QuestionsAssessmentDetails { get; set; }
    }
}
