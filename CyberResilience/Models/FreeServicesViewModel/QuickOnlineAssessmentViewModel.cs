using CyberResilience.Common.App_LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberResilience.Models.FreeServicesViewModel
{
    public class QuickOnlineAssessmentViewModel
    {
        public QuickOnlineAssessmentViewModel()
        {
            BaseQuestions = new List<QuickOnlineAssessmentBaseQuestionsViewModel>();
            Attachments = new List<QuickOnlineAssessmentAttachmentViewModel>();
        }
        public string Template { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public int Id { get; set; }
        public string TemplateNameAr { get; set; }
        public string TemplateNameEn { get; set; }
        public int TemplateType { get; set; }
        public int TemplateSubType { get; set; }
        public string TemplateTypeString { get; set; }
        public string TemplateSubTypeString { get; set; }
        public bool IsEmptyAttachments { get; set; }
        public long? BaseClauseSystemNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public bool IsEmptyQuestions { get; set; }
        public string UserName { get; set; }
        public int ServiceType { get; set; }
        public string ServiceName { get; set; }
        public int ServicePaymentType { get; set; }
        public int ServiceRequestStatus { get; set; }
        public List<QuickOnlineAssessmentBaseQuestionsViewModel> BaseQuestions { get; set; }
        public List<QuickOnlineAssessmentAttachmentViewModel> Attachments { get; set; }
        public IEnumerable<CyberResilience.Common.DTOs.LookupsDTO.LookupsDTO> TemplateTypes { get; set; }
        public IEnumerable<CyberResilience.Common.DTOs.LookupsDTO.LookupsDTO> TemplateSubTypes { get; set; }

    }
}