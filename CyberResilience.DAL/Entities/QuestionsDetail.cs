namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Templates.QuestionsDetails")]
    public partial class QuestionsDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionsDetail()
        {
            Questionnaires = new HashSet<Questionnaire>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string clauseNumberEn { get; set; }

        [StringLength(50)]
        public string clauseNumberAr { get; set; }

        public string clauseNameEn { get; set; }

        public string clauseNameAr { get; set; }

        public long? clauseSystemNumber { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }

        public bool? IsMandatory { get; set; }

        public int BaseQuestionDetailsId { get; set; }

        public virtual QuestionsAssessmentDetail QuestionsAssessmentDetail { get; set; }

        public virtual BaseQuestionsDetail BaseQuestionsDetail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
    }
}
