using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.Area.Admin.Models
{
    public class QuestionnaireTemplateViewModel
    {
        public int Id { get; set; }

        public int StandardId { get; set; }

        public int QuestionnaireTypeId { get; set; }
        public string QuestionnaireType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdateBy { get; set; }

        public string QuestionnaireNameEn { get; set; }

        public string QuestionnaireNameAr { get; set; }

        public int TemplateId { get; set; }
    }
}