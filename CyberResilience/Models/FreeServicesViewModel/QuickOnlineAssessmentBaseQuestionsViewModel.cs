using CyberResilience.Common.App_LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberResilience.Models.FreeServicesViewModel
{
    public class QuickOnlineAssessmentBaseQuestionsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(CyberResilience.Common.App_LocalResources.Resource), ErrorMessageResourceName = "Required")]
        //[RegularExpression("^[0-9 _\u0621-\u064A]+$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "OnlyArabicCharacters")]
        public string BaseQuestionNameAr { get; set; }
        [Required(ErrorMessageResourceType = typeof(CyberResilience.Common.App_LocalResources.Resource), ErrorMessageResourceName = "Required")]
        //[RegularExpression("^[0-9A-Za-z ]+$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "OnlyEnglishCharacters")]
        public string BaseQuestionNameEn { get; set; }
        public string BaseQuestion { get; set; }
        public string BaseClauseNumberEn { get; set; }
        public string BaseClauseNumberAr { get; set; }
        public string BaseClauseNameEn { get; set; }
        public string BaseClauseNameAr { get; set; }
        public long? BaseClauseSystemNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public bool? IsMandatory { get; set; }
        public List<QuickOnlineAssessmentQuestionsViewModel> Questions { get; set; }
        public IEnumerable<CyberResilience.Common.DTOs.LookupsDTO.LookupsDTO> TemplateTypes { get; set; }
        public IEnumerable<CyberResilience.Common.DTOs.LookupsDTO.LookupsDTO> TemplateSubTypes { get; set; }
        public int baseTemplateId { get; set; }
    }
}