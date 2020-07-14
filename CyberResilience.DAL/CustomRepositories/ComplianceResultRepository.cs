using CyberResilience.Common.Utilities;
using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL.CustomRepositories
{
    public class ComplianceResultRepository : Repository<ComplianceResult>
    {
        public ComplianceResultRepository(UnitOfWork uow) : base(uow) { }

        public int AddServiceRequestComplianceResult(ComplianceResult Entity)
        {
            try
            {
                Create(Entity);
                _uow.Save();
                return Entity.Id;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddServiceRequestComplianceResult", "An error occurred while trying to create ComplianceResult Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return 0;
            }


        }
    }
}
