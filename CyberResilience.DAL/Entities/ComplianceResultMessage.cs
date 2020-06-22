namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ComplianceResultMessage
    {
        public int Id { get; set; }

        public string ImplementationPeriodTimeMessageEn { get; set; }

        public string ImplementationPeriodTimeMessageAr { get; set; }

        public int ImplementationPeriodTimeValue { get; set; }

        public int? ComplianceResultValue { get; set; }
    }
}
