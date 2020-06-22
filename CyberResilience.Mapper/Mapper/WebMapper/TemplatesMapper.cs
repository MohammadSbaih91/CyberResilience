using CyberResilience.Area.Admin.Models;
using CyberResilience.Common.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Mapper.Mapper.WebMapper
{
    public class TemplatesMapper
    {
        public List<TemplateViewModel> ConvertTemplatesToWeb(List<TemplateDTO> templates)
        {
            List<TemplateViewModel> templatesList = new List<TemplateViewModel>();
            if (templates == null)
            {
                return templatesList;
            }
            foreach(var template in templates)
            {
                var newTemplate = new TemplateViewModel()
                {
                    Id = template.Id,
                    TemplateNameAr = template.TemplateNameAr,
                    TemplateNameEn = template.TemplateNameEn,
                    TemplateSubType = template.TemplateSubType,
                    TemplateType = template.TemplateType
                };
                templatesList.Add(newTemplate);
            }
            return templatesList;
        }



    }
}
