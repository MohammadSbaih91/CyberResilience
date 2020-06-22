namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Templates.MandatoryValuesAndWeights")]
    public partial class MandatoryValuesAndWeight
    {
        public int Id { get; set; }

        public int MandatoryRequirementValue { get; set; }

        public decimal MandatoryRequirementWeight { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }
    }
}
