using CyberResilience.Common.App_LocalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberResilience.Models.FreeServicesViewModel
{
    public class QuickOnlineAssessmentQuestionsViewModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string clauseNumberEn { get; set; }
        public string clauseNumberAr { get; set; }
        [DataType(DataType.MultilineText)]
        //[Required(ErrorMessageResourceType = typeof(CyberResilience.Common.App_LocalResources.Resource), ErrorMessageResourceName = "Required")]
        //[RegularExpression("^[\u0000-\u007F]+$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "OnlyEnglishCharacters")]
        public string clauseNameEn { get; set; }
        [DataType(DataType.MultilineText)]
        //[Required(ErrorMessageResourceType = typeof(CyberResilience.Common.App_LocalResources.Resource), ErrorMessageResourceName = "Required")]
        //[RegularExpression("^[\u0621-\u064A\u0660-\u0669 ]+$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "OnlyArabicCharacters")]
        public string clauseNameAr { get; set; }
        public long? clauseSystemNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public bool? IsMandatory { get; set; }
        public int BaseQuestionDetailsId { get; set; }
        public string QuestionAr { get; set; }
        public string QuestionEn { get; set; }

        public string BaseQuestionAr { get; set; }
        public string BaseQuestionEn { get; set; }
        [Required(ErrorMessageResourceType = typeof(CyberResilience.Common.App_LocalResources.Resource), ErrorMessageResourceName = "Required")]
        public int ComplianceLevelValue { get; set; }
        public IEnumerable<Common.DTOs.LookupsDTO.LookupsDTO> ComplianceLevel { get; set; }
        public List<QuickOnlineAssessmentAttachmentViewModel> questionAttachments { get; set; }
    }
}