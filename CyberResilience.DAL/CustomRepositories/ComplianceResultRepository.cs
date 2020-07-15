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
        public ComplianceResult GetQuickOnlineAssessmentResult(int ServiceRequestId, string UserName)
        {
            try
            {
                var record = GetQuerable(x => x.ServiceRequestId == ServiceRequestId).Select(u => new ComplianceResult()
                {
                    CreatedBy=u.CreatedBy,
                    ServiceRequestId=u.ServiceRequestId,
                    CreatedDate=u.CreatedDate,
                    ImplementationPeriodAccurateExpectedTime=u.ImplementationPeriodAccurateExpectedTime,
                    Id=u.Id,
                    ImplementationPeriodTime=u.ImplementationPeriodTime,
                    IsArchived=u.IsArchived,
                    IsDeleted=u.IsDeleted,
                    IsUpdated=u.IsUpdated,
                    QuestionnaireAccurateComplianceResult=u.QuestionnaireAccurateComplianceResult,
                    QuestionnaireComplianceResult=u.QuestionnaireComplianceResult,
                    QuestionsAssessmentDetails=u.QuestionsAssessmentDetails
                }).FirstOrDefault();

                return record;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetQuickOnlineAssessmentResult", "An error occurred while trying to  Get QuickOnlineAssessmentResult Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return null;
            }
        }
    }
}
