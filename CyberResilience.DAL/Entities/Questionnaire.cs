namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Users.Questionnaires")]
    public partial class Questionnaire
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int StandardId { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int QuestionsDetailsId { get; set; }

        public int AsessmentDetailsId { get; set; }

        public int ComplianceResultId { get; set; }

        public int QuestionnaireTypeId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Lookup Lookup { get; set; }

        public virtual ServiceRequest ServiceRequest { get; set; }

        public virtual Standard Standard { get; set; }

        public virtual ComplianceResult ComplianceResult { get; set; }

        public virtual QuestionsAssessmentDetail QuestionsAssessmentDetail { get; set; }
    }
}
