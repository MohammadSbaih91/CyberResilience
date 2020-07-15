using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.Models.FreeServicesViewModel
{
    public class QuickOnlineAssessmentResultViewModel
    {
        public int Id { get; set; }
        public double QuestionnaireAccurateComplianceResult { get; set; }
        public int QuestionnaireComplianceResult { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public bool? IsArchived { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsUpdated { get; set; }
        public int? ImplementationPeriodTime { get; set; }
        public DateTime? ImplementationPeriodAccurateExpectedTime { get; set; }
    }
}