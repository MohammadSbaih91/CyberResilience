using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.ServiceRequestsDTO
{
    public class UserServicesDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public string UserID { get; set; }
        public int ServiceType { get; set; }
        public string ServiceName { get; set; }
        public int ServicePaymentType { get; set; }
        public int ServiceRequestStatus { get; set; }


        public List<QuickOnlineAssessmentResultDTO> AssessmentResults { get; set; }
    }
}
