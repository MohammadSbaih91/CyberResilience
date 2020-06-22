using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.Admin.SettingsDTO
{
   public class QuestionsDetailsSettingsDTO
    {
        public int Id { get; set; }

        public string clauseNumberEn { get; set; }

        public string clauseNumberAr { get; set; }

        public string clauseNameEn { get; set; }

        public string clauseNameAr { get; set; }

        public long? clauseSystemNumber { get; set; }

        public bool? IsRootQuestion { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdateBy { get; set; }

        public int? RootQuestionOrder { get; set; }

        public bool? IsMandatory { get; set; }
    }
}
