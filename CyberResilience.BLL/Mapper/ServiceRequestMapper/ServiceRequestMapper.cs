using CyberResilience.Common.DTOs.ServiceRequestsDTO;
using CyberResilience.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CyberResilience.Common.Enums;

namespace CyberResilience.BLL.Mapper.ServiceRequestMapper
{
    public class ServiceRequestMapper
    {
        //public List<ServiceRequest> ConvertServiceRequestToDAL(List<ServiceRequestsDTO> dtos)
        //{
        //    List<ServiceRequest> entities = new List<ServiceRequest>();
        //    if (dtos == null)
        //    {
        //        return entities;
        //    }
        //    foreach (var dto in dtos)
        //    {
        //        var newEntity = new ServiceRequest()
        //        {
        //            CreatedBy = dto.CreatedBy,
        //            LastUpdateBy = dto.LastUpdateBy,
        //            CreatedDate = dto.CreatedDate,
        //            LastUpdateDate = dto.LastUpdateDate,
        //            ServiceName = dto.ServiceName,
        //            ServicePaymentType = dto.ServicePaymentType,
        //            ServiceRequestStatus = dto.ServiceRequestStatus,
        //            UserId = dto.UserID,
        //            ServiceType = dto.ServiceType,
        //            QuestionsAssessmentDetail

        //        };
        //        entities.Add(newEntity);
        //    }
        //    return entities;
        //}
        public ServiceRequest ConvertServiceRequestDTOToDAL(ServiceRequestsDTO dto)
        {
            ServiceRequest entity = new ServiceRequest();
            if (dto == null)
            {
                return entity;
            }
            entity.CreatedBy = dto.CreatedBy;
            entity.CreatedDate = dto.CreatedDate;
            entity.ServiceName = dto.ServiceName;
            entity.ServicePaymentType = dto.ServicePaymentType;
            entity.ServiceRequestStatus = dto.ServiceRequestStatus;
            entity.ServiceType = dto.ServiceType;
            entity.UserId = dto.UserID;
            entity.Id = dto.Id;

            return entity;
            //entity.QuestionsAssessmentDetails = ConvertBaseQuestionsDetailsDTOToDAL(dto.BaseQuestions);

        }
        public List<QuestionsAssessmentDetail> ConvertBaseQuestionsDetailsToQuestionsAssessment(List<BaseQuestionsDetailsDTO> dto, int ServiceRequestId)
        {
            List<QuestionsAssessmentDetail> entities = new List<QuestionsAssessmentDetail>();
            if (dto == null)
            {
                return entities;
            }
            foreach (var item in dto)
            {
                foreach (var subitem in item.questions)
                {
                    var newEntity = new QuestionsAssessmentDetail()
                    {
                        CreatedBy = subitem.CreatedBy,
                        CreatedDate = subitem.CreatedDate,
                        QuestionDetailsId = subitem.Id,
                        ServiceRequestId = ServiceRequestId,
                        QuestionTopAddedValueToAssemssment = (subitem.IsMandatory == true) ? 1 : 0.5,
                        QuestionAssessmentValue = CalculateQuestionAssessmentValue(subitem.IsMandatory.HasValue ? subitem.IsMandatory.Value : false, subitem.ComplianceLevelValue),
                    };
                    entities.Add(newEntity);
                }
            }
            return entities;


        }
        private double CalculateQuestionAssessmentValue(bool IsMandatory, int ComplianceLevelValue)
        {
            double TopValue = (IsMandatory == true) ? 1 : 0.5;
            double value=0.0;
            switch (ComplianceLevelValue)
            {
                case (int)ComplianceLevel.NotExist:
                    value = (TopValue == 1) ? 0.25 : 0.20;
                    break;
                case (int)ComplianceLevel.ExistInPractice:
                    value = (TopValue == 1) ? 0.5 : 0.30;
                    break;
                case (int)ComplianceLevel.ExistAndImplemntingWithoutAuditing:
                    value = (TopValue == 1) ? 0.75 : 0.4;
                    break;
                case (int)ComplianceLevel.StrictlyComplyWithStandard:
                    value = (TopValue == 1) ? 1.0 : 0.5;
                    break;
                default:
                    value = (TopValue == 1) ? 0.0 : 0.1; //(int)ComplianceLevel.NotUnderstanding;
                    break;
            }
            return value;
        }
        public QuickOnlineAssessmentResultDTO ConvertToQuickOnlineAssessmentResultDTO(ComplianceResult entity)
        {
            QuickOnlineAssessmentResultDTO dto = new QuickOnlineAssessmentResultDTO();
            if (entity == null)
            {
                return dto;
            }
            dto.QuestionnaireAccurateComplianceResult = entity.QuestionnaireAccurateComplianceResult;
            dto.CreatedBy = entity.CreatedBy;
            dto.CreatedDate = entity.CreatedDate;
            dto.Id = entity.Id;
            dto.ImplementationPeriodAccurateExpectedTime = entity.ImplementationPeriodAccurateExpectedTime;
            dto.ImplementationPeriodTime = entity.ImplementationPeriodTime;
            dto.IsArchived = entity.IsArchived;
            dto.IsDeleted = entity.IsDeleted;
            dto.IsUpdated = entity.IsUpdated;
            dto.QuestionnaireComplianceResult =Convert.ToInt32(entity.QuestionnaireAccurateComplianceResult);
            return dto;
        }
    }
}
