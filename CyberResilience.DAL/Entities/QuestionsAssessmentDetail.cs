namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Questionnaire.QuestionsAssessmentDetails")]
    public partial class QuestionsAssessmentDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionsAssessmentDetail()
        {
            Questionnaires = new HashSet<Questionnaire>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int QuestionTopAddedValueToAssemssment { get; set; }

        public decimal QuestionAssessmentValue { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }

        public int ComplianceResultId { get; set; }

        public virtual ComplianceResult ComplianceResult { get; set; }

        public virtual QuestionsDetail QuestionsDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
    }
}
