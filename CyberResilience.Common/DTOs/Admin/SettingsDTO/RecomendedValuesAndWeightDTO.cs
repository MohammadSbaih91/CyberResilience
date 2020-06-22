using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.Admin.SettingsDTO
{
   public class RecomendedValuesAndWeightDTO
    {
        public int Id { get; set; }

        public int RecomendedRequirementValue { get; set; }

        public decimal RecomendedRequirementWeight { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdateBy { get; set; }
    }
}
