﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.ServiceRequestsDTO
{
    public class BaseQuestionsDetailsDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CreatedBy { get; set; }
        //public string LastUpdateBy { get; set; }
        public string BaseQuestionNumberEn { get; set; }
        public string BaseQuestionNumberAr { get; set; }
        public string BaseQuestionNameEn { get; set; }
        public string BaseQuestionNameAr { get; set; }
        public long? clauseSystemNumber { get; set; }
        public bool? IsRootQuestion { get; set; }
        public int? RootQuestionOrder { get; set; }
        public bool? IsMandatory { get; set; }
        public int baseTemplateId { get; set; }
        public List<QuestionsDetailsDTO> questions { get; set; }


    }
}
