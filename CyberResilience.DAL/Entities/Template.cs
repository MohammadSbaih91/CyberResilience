namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Template
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Template()
        {
            BaseQuestionsDetails = new HashSet<BaseQuestionsDetail>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string TemplateNameAr { get; set; }

        [StringLength(250)]
        public string TemplateNameEn { get; set; }

        public int TemplateType { get; set; }

        public int TemplateSubType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseQuestionsDetail> BaseQuestionsDetails { get; set; }
    }
}
