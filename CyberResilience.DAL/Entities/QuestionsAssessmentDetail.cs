namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceRequests.QuestionsAssessmentDetails")]
    public partial class QuestionsAssessmentDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public double QuestionTopAddedValueToAssemssment { get; set; }

        public double QuestionAssessmentValue { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }

        public int QuestionDetailsId { get; set; }

        public int ServiceRequestId { get; set; }

        public int ComplianceResultId { get; set; }

        public virtual ServiceRequest ServiceRequest { get; set; }

        public virtual ComplianceResult ComplianceResult { get; set; }

        public virtual QuestionsDetail QuestionsDetail { get; set; }
    }
}
