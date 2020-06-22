using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.CompliancesDTO
{
    public class ComplianceResultMessageDTO
    {
        public int Id { get; set; }

        public string ImplementationPeriodTimeMessageEn { get; set; }

        public string ImplementationPeriodTimeMessageAr { get; set; }

        public int ImplementationPeriodTimeValue { get; set; }

        public int? ComplianceResultValue { get; set; }
    }
}
