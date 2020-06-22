namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Templates.BaseQuestionsDetails")]
    public partial class BaseQuestionsDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseQuestionsDetail()
        {
            QuestionsDetails = new HashSet<QuestionsDetail>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string BaseClauseNumberEn { get; set; }

        [StringLength(50)]
        public string BaseClauseNumberAr { get; set; }

        public string BaseClauseNameEn { get; set; }

        public string BaseClauseNameAr { get; set; }

        public long? BaseClauseSystemNumber { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }

        public bool? IsMandatory { get; set; }

        public int TemplateId { get; set; }

        public virtual Template Template { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionsDetail> QuestionsDetails { get; set; }
    }
}
