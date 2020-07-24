using CyberResilience.Common.DTOs.Admin.QuestionnairesDTO;
using CyberResilience.Common.DTOs.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.Admin
{
    public class TemplateDTO
    {

        public int Id { get; set; }
        public string ServiceRequestName { get; set; }
        public string ServiceRequestNameCode { get; set; }
        public string TemplateNameAr { get; set; }
        public string TemplateNameEn { get; set; }
        public int TemplateType { get; set; }
        public int TemplateSubType { get; set; }
        public bool WithNoQuestions { get; set; }
        public bool WithNoAttachments { get; set; }
        public List<BaseQuestionsDetailsDTO> baseQuestions { get; set; }
        public List<AttachmentDTO> attachments { get; set; }
    }
}
