using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.ServiceRequestsDTO
{
    public class QuestionsDetailsDTO
    {
        public int Id { get; set; }
        public int ComplianceLevelValue { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdateBy { get; set; }
        public string NumberEn { get; set; }
        public string NumberAr { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public long? clauseSystemNumber { get; set; }
        public bool? IsRootQuestion { get; set; }
        public int? RootQuestionOrder { get; set; }
        public bool? IsMandatory { get; set; }
        public int BaseQuestionDetailsId { get; set; }
        public string BaseQuestionAr { get; set; }
        public string BaseQuestionEn { get; set; }
        public IEnumerable<CyberResilience.Common.DTOs.LookupsDTO.LookupsDTO> CompianceLevel { get; set; }
        public IEnumerable<CyberResilience.Common.DTOs.LookupsDTO.LookupsDTO> TemplateTypes { get; set; }
    }
}
