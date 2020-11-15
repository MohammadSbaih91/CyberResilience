using CyberResilience.Area.Admin.Models;
using CyberResilience.Common.DTOs.Admin.ToolkitDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.Mapper.WebMapper
{
    public class ToolkitsMapper
    {
        public List<ToolkitViewModel> ConvertToolkitsToWeb(List<ToolkitDTO> templates)
        {
            List<ToolkitViewModel> templatesList = new List<ToolkitViewModel>();
            if (templates == null)
            {
                return templatesList;
            }
            foreach (var template in templates)
            {
                var newTemplate = new ToolkitViewModel()
                {
                    Id = template.Id,
                    caption = template.caption,
                    contentType = template.contentType,
                    data = template.data,
                    ToolkitArabicName = template.ToolkitArabicName,
                    ToolkitAttachmentFileName = template.ToolkitAttachmentFileName,
                    ToolkitAttachmentType = template.ToolkitAttachmentType,
                    ToolkitName = template.ToolkitName,
                    ToolkitType = template.ToolkitType,
                    ToolkitTypeName = template.ToolkitTypeName,

                };
                templatesList.Add(newTemplate);
            }
            return templatesList;
        }
        public ToolkitViewModel ConvertToolkitToWeb(ToolkitDTO toolkit)
        {
            ToolkitViewModel newTemplate = new ToolkitViewModel();
            if (toolkit == null)
            {
                return newTemplate;
            }
            newTemplate.Id = toolkit.Id;
            newTemplate.caption = toolkit.caption;
            newTemplate.contentType = toolkit.contentType;
            newTemplate.data = toolkit.data;
            newTemplate.ToolkitArabicName = toolkit.ToolkitArabicName;
            newTemplate.ToolkitAttachmentFileName = toolkit.ToolkitAttachmentFileName;
            newTemplate.ToolkitAttachmentType = toolkit.ToolkitAttachmentType;
            newTemplate.ToolkitName = toolkit.ToolkitName+toolkit.contentType;
            newTemplate.ToolkitType = toolkit.ToolkitType;
            newTemplate.ToolkitTypeName = toolkit.ToolkitTypeName;

            return newTemplate;
        }
        public  ToolkitDTO ConvertToolkitToBLL(ToolkitViewModel toolkit)
        {
            ToolkitDTO newTemplate = new ToolkitDTO();
            if (toolkit == null)
            {
                return newTemplate;
            }
            newTemplate.Id = toolkit.Id;
            newTemplate.caption = toolkit.caption;
            newTemplate.contentType = toolkit.contentType;
            newTemplate.data = toolkit.data;
            newTemplate.ToolkitArabicName = toolkit.ToolkitArabicName;
            newTemplate.ToolkitAttachmentFileName = toolkit.ToolkitAttachmentFileName;
            newTemplate.ToolkitAttachmentType = toolkit.ToolkitAttachmentType;
            newTemplate.ToolkitName = toolkit.ToolkitName;
            newTemplate.ToolkitType = toolkit.ToolkitType;
            newTemplate.ToolkitTypeName = toolkit.ToolkitTypeName;

            return newTemplate;
        }
    }
}