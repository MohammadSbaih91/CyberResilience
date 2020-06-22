namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Templates.RecomendedValuesAndWeights")]
    public partial class RecomendedValuesAndWeight
    {
        public int Id { get; set; }

        public int RecomendedRequirementValue { get; set; }

        public decimal RecomendedRequirementWeight { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        [StringLength(250)]
        public string LastUpdateBy { get; set; }
    }
}
