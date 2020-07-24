using CyberResilience.BLL.Mapper.ServiceRequestMapper;
using CyberResilience.Common.DTOs.ServiceRequestsDTO;
using CyberResilience.Common.Utilities;
using CyberResilience.DAL;
using CyberResilience.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CyberResilience.Common.Enums;

namespace CyberResilience.BLL.ServiceRequestsBusinessLogic
{
    public class ServiceRequestBusinessLogic
    {
        private ServiceRequestMapper _ServiceRequestMapper;
        public ServiceRequestBusinessLogic()
        {
            _ServiceRequestMapper = new ServiceRequestMapper();
        }
        public int CreateServiceRequest(ServiceRequestsDTO dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var entity = _ServiceRequestMapper.ConvertServiceRequestDTOToDAL(dto);

                    var ServiceRequestAdded = uow.ServiceRequests.CreateServiceRequest(dto);
                    if (ServiceRequestAdded > 0)
                    {
                        var QuestionsAssessmentDetail = _ServiceRequestMapper.ConvertBaseQuestionsDetailsToQuestionsAssessment(dto.BaseQuestions, ServiceRequestAdded);


                        var ComplianceResultEntity = CalculateComplianceResult(QuestionsAssessmentDetail);
                        ComplianceResultEntity.CreatedBy = dto.CreatedBy;
                        ComplianceResultEntity.CreatedDate = DateTime.Now;
                        ComplianceResultEntity.IsArchived = false;
                        ComplianceResultEntity.IsDeleted = false;
                        ComplianceResultEntity.IsUpdated = false;
                        ComplianceResultEntity.ServiceRequestId = ServiceRequestAdded;

                        int ComplianceResultRecordId = uow.ComplianceResult.AddServiceRequestComplianceResult(ComplianceResultEntity);

                        foreach (var item in QuestionsAssessmentDetail)
                        {
                            item.ComplianceResultId = ComplianceResultRecordId;
                        }
                        bool IsAdded = uow.QuestionsAssessmentDetails.AddQuestionsAssessmentDetails(QuestionsAssessmentDetail);
                        return ServiceRequestAdded;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("CreateServiceRequest", "An error occurred while trying to create ServiceRequest Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return 0;
                }
            }
        }
        private ComplianceResult CalculateComplianceResult(List<QuestionsAssessmentDetail> QuestionsAssessmentResult)
        {
            ComplianceResult entity = new ComplianceResult();
            var QuestionsAssessmentValues = new List<double>();
            var QuestionsAssessmentFixedValues = new List<double>();
            foreach (var item in QuestionsAssessmentResult)
            {
                QuestionsAssessmentValues.Add(item.QuestionAssessmentValue);
                QuestionsAssessmentFixedValues.Add(item.QuestionTopAddedValueToAssemssment);
            }
            entity.QuestionnaireAccurateComplianceResult = (QuestionsAssessmentValues.Sum() / QuestionsAssessmentFixedValues.Sum()) * 100;
            entity.ImplementationPeriodTime = CalculateImplementationPeriodTime(entity.QuestionnaireAccurateComplianceResult);
            entity.ImplementationPeriodAccurateExpectedTime = DateTime.Now.AddMonths(entity.ImplementationPeriodTime.Value);

            return entity;
        }
        private int CalculateImplementationPeriodTime(double QuestionnaireAccurateComplianceResult)
        {
            int Value = Convert.ToInt32(QuestionnaireAccurateComplianceResult);
            if (Value < 10)
            {
                return 6;
            }
            else if (Value < 29)
            {
                return 5;
            }
            else if (Value < 49)
            {
                return 4;
            }
            else if (Value < 69)
            {
                return 3;
            }
            else if (Value < 89)
            {
                return 2;
            }
            else if (Value < 99)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public QuickOnlineAssessmentResultDTO GetQuickOnlineAssessmentResult(int ServiceRequestId, string UserName)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var OnlineAssessmentResult = _ServiceRequestMapper.ConvertToQuickOnlineAssessmentResultDTO(uow.ComplianceResult.GetQuickOnlineAssessmentResult(ServiceRequestId, UserName));
                    if (OnlineAssessmentResult != null)
                    {
                        return OnlineAssessmentResult;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetTemplate", "An error occurred while trying to get  Template Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }

        }

        public bool DeleteAssessmentResult(int QuickAssessmentResultId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    bool isDeleted = uow.ComplianceResult.DeleteAssessmentResult(QuickAssessmentResultId);
                    return isDeleted;
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetTemplate", "An error occurred while trying to get  Template Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }

        public bool DraftAssessmentResult(int QuickAssessmentResultId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    bool isDrafted = uow.ComplianceResult.DraftAssessmentResult(QuickAssessmentResultId);
                    return isDrafted;
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetTemplate", "An error occurred while trying to get  Template Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }

        public bool ConsultationServiceRequest(int QuickAssessmentResultId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    bool InConsultation = uow.ComplianceResult.ConsultationServiceRequest(QuickAssessmentResultId);
                    return InConsultation;
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetTemplate", "An error occurred while trying to get  Template Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }


        public List<UserServicesDTO> GetUserServices(string UserName, out int totalRecords, int page = 1, int pageSize = 10)
        {
            List<UserServicesDTO> services = new List<UserServicesDTO>();
            totalRecords = 0;
            using (var uow = new UnitOfWork())
            {
                try
                {
                    string UserId = uow.AspNetUsers.GetUserIdByUserName(UserName);
                     services = uow.ServiceRequests.GetUserServices(UserId);

                    totalRecords = services.Count();
                    services = services.OrderByDescending(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                    return services.ToList();
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetUserServices", "An error occurred while trying to GetUserServices Records  UserName - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return services;
                }
            }
        }
    }
}
