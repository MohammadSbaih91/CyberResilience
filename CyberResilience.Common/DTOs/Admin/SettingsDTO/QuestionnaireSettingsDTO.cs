using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.Admin.SettingsDTO
{
  public  class QuestionnaireSettingsDTO
    {
        public int Id { get; set; }

        public int StandardId { get; set; }

        public string UserId { get; set; }

        public int QuestionsDetailsId { get; set; }

        public int AsessmentDetailsId { get; set; }

        public int ComplianceResultId { get; set; }

        public int QuestionnaireTypeId { get; set; }
    }
}
