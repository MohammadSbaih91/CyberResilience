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
                //string UserId = _uow.AspNetUsers.GetUserIdByUserName(UserName);
                var record = GetQuerable(x => x.ServiceRequestId == ServiceRequestId && x.CreatedBy == UserName).FirstOrDefault();

                record.CreatedBy = record.CreatedBy;
                record.ServiceRequestId = record.ServiceRequestId;
                record.CreatedDate = record.CreatedDate;
                record.ImplementationPeriodAccurateExpectedTime = record.ImplementationPeriodAccurateExpectedTime;
                record.Id = record.Id;
                record.ImplementationPeriodTime = record.ImplementationPeriodTime;
                record.IsArchived = record.IsArchived;
                record.IsDeleted = record.IsDeleted;
                record.IsUpdated = record.IsUpdated;
                record.QuestionnaireAccurateComplianceResult = record.QuestionnaireAccurateComplianceResult;
                record.QuestionsAssessmentDetails = record.QuestionsAssessmentDetails;

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



        public bool DeleteAssessmentResult(int QuickAssessmentResultId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == QuickAssessmentResultId).FirstOrDefault();
                if (record != null)
                {
                    record.IsDeleted = true;
                    Update(record);
                    _uow.Save();
                    return true;
                }
                else
                {
                    _uow.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("ComplianceResult ", "An error occurred while trying to DeleteAssessmentResult record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }

        public bool DraftAssessmentResult(int QuickAssessmentResultId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == QuickAssessmentResultId).FirstOrDefault();
                if (record != null)
                {
                    record.IsArchived = true;
                    Update(record);
                    _uow.Save();
                    return true;
                }
                else
                {
                    _uow.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("ComplianceResult ", "An error occurred while trying to DraftAssessmentResult record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }


        public bool ConsultationServiceRequest(int QuickAssessmentResultId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == QuickAssessmentResultId).FirstOrDefault();
                if (record != null)
                {
                    record.InConsultant = true;
                    Update(record);
                    _uow.Save();
                    return true;
                }
                else
                {
                    _uow.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("ComplianceResult ", "An error occurred while trying to DeleteAssessmentResult record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
    }
}
