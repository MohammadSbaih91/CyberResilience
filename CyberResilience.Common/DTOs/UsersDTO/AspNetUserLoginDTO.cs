using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.UsersDTO
{
   public class AspNetUserLoginDTO
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public string UserId { get; set; }
    }
}
