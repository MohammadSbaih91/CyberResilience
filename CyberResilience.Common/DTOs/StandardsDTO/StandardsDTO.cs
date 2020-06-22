using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.StandardsDTO
{
   public class StandardsDTO
    {
        public int Id { get; set; }

        public string StandardNameEn { get; set; }

        public string StandardNameAr { get; set; }

        public int? StandardNumber { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdateBy { get; set; }

        public int? StandardTypeId { get; set; }


    }
}
