using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.ServiceRequestsDTO
{
   public class ServiceRequestsDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdateBy { get; set; }

    }
}
