using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.Admin.QuestionnairesDTO
{
    public class QuestionnaireTemplateDTO
    {
        public int Id { get; set; }

        public int StandardId { get; set; }

        public int QuestionnaireTypeId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdateBy { get; set; }

        public string QuestionnaireNameEn { get; set; }

        public string QuestionnaireNameAr { get; set; }
    }
}
