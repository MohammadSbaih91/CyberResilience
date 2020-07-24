using CyberResilience.Models.FreeServicesViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberResilience.Models.PlatformViewModel
{
    public class ServiceRequestViewModel
    {
        public int Id { get; set; }

        public int ServiceType { get; set; }

        public string ServiceName { get; set; }

        public string UserId { get; set; }

        public int ServicePaymentType { get; set; }

        public int ServiceRequestStatus { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? CreatedDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? LastUpdateDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdateBy { get; set; }

        public string ServiceRequestType { get; set; }

        public string ServiceStatus { get; set; }

        public string PaymentType { get; set; }

        public List<QuickOnlineAssessmentResultViewModel> AssessmentResults { get; set; }


    }
}