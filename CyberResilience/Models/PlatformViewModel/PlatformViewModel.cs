using CyberResilience.Models.FreeServicesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.Models.PlatformViewModel
{
    public class PlatformViewModel
    {
        public IEnumerable<ServiceRequestViewModel> Services { get; set; }
        public IEnumerable<QuickOnlineAssessmentResultViewModel> AssessmentResults { get; set; }
    }
}