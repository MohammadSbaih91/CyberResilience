using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.ServiceRequestsDTO
{
    public class QuestionsAssessmentDetailsDTO : ServiceRequestsDTO
    {

        public int QuestionTopAddedValueToAssemssment { get; set; }
        public decimal QuestionAssessmentValue { get; set; }
        public int ComplianceResultId { get; set; }
    }
}
