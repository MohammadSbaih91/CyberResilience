using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CyberResilience.Common.App_LocalResources;
using System.Web;

namespace CyberResilience.Area.Admin.Models
{
    public class BaseTemplateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Required", ErrorMessage = null)]
        [RegularExpression("^[0-9 _\u0621-\u064A]+$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "OnlyArabicCharacters")]
        public string TemplateNameAr { get; set; }
        [Required(ErrorMessageResourceType = typeof(CyberResilience.Common.App_LocalResources.Resource), ErrorMessageResourceName = "Required")]
        [RegularExpression("^[A-Za-z\\d_-]+$", ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "OnlyEnglishCharacters")]
        public string TemplateNameEn { get; set; }
        [Required(ErrorMessageResourceType = typeof(CyberResilience.Common.App_LocalResources.Resource), ErrorMessageResourceName = "Required")]

        public int TemplateType { get; set; }
        [Required(ErrorMessageResourceType = typeof(CyberResilience.Common.App_LocalResources.Resource), ErrorMessageResourceName = "Required")]
        public int TemplateSubType { get; set; }

        public IEnumerable<CyberResilience.Common.DTOs.LookupsDTO.LookupsDTO> TemplateTypes { get; set; }

        public IEnumerable<CyberResilience.Common.DTOs.LookupsDTO.LookupsDTO> TemplateSubTypes { get; set; }

    }
}