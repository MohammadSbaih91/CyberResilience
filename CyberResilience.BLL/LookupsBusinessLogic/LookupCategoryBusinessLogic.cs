using CyberResilience.Common;
using CyberResilience.Common.DTOs.LookupsDTO;
using CyberResilience.Common.Exceptions;
using CyberResilience.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.BLL.LookupsBusinessLogic
{
   public class LookupCategoryBusinessLogic
    {
        public IEnumerable<LookupsDTO> GetLookupsByLookupCategoryCode(string lookupCategoryCode, Enums.Culture cul)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.LookupCategory;
                var lookup = repo.GetLookupsByLookupCategoryCode(lookupCategoryCode, cul);
                if (lookup == null)
                {
                    throw new BusinessException("Lookup does not exist", Constants.ErrorsCodes.LookupDoesNotExist);
                }
                else
                {
                    return lookup;
                }
            }
        }
    }
}
