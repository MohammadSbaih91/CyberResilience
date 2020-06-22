namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Questionnaire.ComplianceResults")]
    public partial class ComplianceResult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComplianceResult()
        {
            QuestionsAssessmentDetails = new HashSet<QuestionsAssessmentDetail>();
            Questionnaires = new HashSet<Questionnaire>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public decimal QuestionnaireAccurateComplianceResult { get; set; }

        public int QuestionnaireComplianceResult { get; set; }

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

        public virtual ServiceRequest ServiceRequest { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionsAssessmentDetail> QuestionsAssessmentDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
    }
}
