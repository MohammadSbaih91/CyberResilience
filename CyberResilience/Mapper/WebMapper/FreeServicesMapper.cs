using CyberResilience.Base;
using CyberResilience.BLL.LookupsBusinessLogic;
using CyberResilience.Common;
using CyberResilience.Common.DTOs.Admin;
using CyberResilience.Common.DTOs.ServiceRequestsDTO;
using CyberResilience.Models.FreeServicesViewModel;
using CyberResilience.Models.PlatformViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static CyberResilience.Common.Constants;
using static CyberResilience.Common.Enums;

namespace CyberResilience.Mapper.WebMapper
{
    public class FreeServicesMapper
    {
        private LookupCategoryBusinessLogic _LookupCategoryBusinessLogic;
        private LookupsBusinessLogic _LookupsBusinessLogic;

        public FreeServicesMapper()
        {
            _LookupCategoryBusinessLogic = new LookupCategoryBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
        }
        public QuickOnlineAssessmentViewModel ConvertQuickOnlineAssessmentToWeb(TemplateDTO template, Culture cul, string SubType)
        {
            QuickOnlineAssessmentViewModel templateUI = new QuickOnlineAssessmentViewModel();
            if (template == null)
            {
                return templateUI;
            }
            templateUI = new QuickOnlineAssessmentViewModel()
            {
                ServiceType = (int)Enums.TemplateTypes.Quastionnaire,
                Id = template.Id,
                //ServiceName= _LookupsBusinessLogic.GetLookupByLookupCode(template.ServiceRequestNameCode, cul).Value,
                TemplateNameAr = template.TemplateNameAr,
                ServiceName = _LookupsBusinessLogic.GetLookupByLookupCode(TemplatesType.Quastionnaire + SubType, cul).Value,
                TemplateNameEn = template.TemplateNameEn,
                TemplateSubType = template.TemplateSubType,
                TemplateType = template.TemplateType,
                TemplateTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", cul),
                TemplateSubTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", cul),
                IsEmptyQuestions = template.WithNoQuestions,
                IsEmptyAttachments = template.WithNoAttachments,
                BaseQuestions = (from e in template.baseQuestions.Where(u => u.Id >= 0)
                                 select new QuickOnlineAssessmentBaseQuestionsViewModel()
                                 {
                                     baseTemplateId = template.Id,
                                     BaseQuestionNameAr = e.BaseQuestionNameAr,
                                     Id = e.Id,
                                     BaseQuestionNameEn = e.BaseQuestionNameEn,
                                     BaseClauseNumberAr = e.BaseQuestionNumberAr,
                                     BaseClauseNameAr = e.BaseQuestionNameAr,
                                     BaseClauseNameEn = e.BaseQuestionNameEn,
                                     BaseClauseNumberEn = e.BaseQuestionNumberEn,
                                     BaseClauseSystemNumber = e.clauseSystemNumber,
                                     CreatedBy = e.CreatedBy,
                                     BaseQuestion = (cul == CyberResilience.Common.Enums.Culture.Arabic) ? e.BaseQuestionNameAr : e.BaseQuestionNameEn,
                                     CreatedDate = e.CreatedDate,
                                     IsMandatory = e.IsMandatory.HasValue ? e.IsMandatory.Value : false,
                                     Questions = (from t in e.questions.Where(u => u.Id > 0)
                                                  select new QuickOnlineAssessmentQuestionsViewModel()
                                                  {

                                                      BaseQuestionDetailsId = e.Id,
                                                      Question = (cul == CyberResilience.Common.Enums.Culture.Arabic) ? t.NameAr : t.NameEn,
                                                      clauseNameAr = t.NameAr,
                                                      Id = t.Id,
                                                      clauseNameEn = t.NameEn,
                                                      clauseNumberAr = t.NumberAr,
                                                      QuestionAr = t.NameAr,
                                                      QuestionEn = t.NameEn,
                                                      clauseNumberEn = t.NumberEn,
                                                      clauseSystemNumber = t.clauseSystemNumber,
                                                      CreatedBy = t.CreatedBy,
                                                      CreatedDate = t.CreatedDate,
                                                      ComplianceLevel = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ComplianceLevel", cul).ToList(),
                                                      IsMandatory = t.IsMandatory.HasValue ? e.IsMandatory.Value : false,
                                                      questionAttachments = (from r in t.QuestionsAttachments.Where(u => u.Id > 0)
                                                                             select new QuickOnlineAssessmentAttachmentViewModel()
                                                                             {
                                                                                 AttachmentID = r.AttachmentID,
                                                                                 AttachmentId = r.AttachmentId,
                                                                                 Caption = r.Caption,
                                                                                 ContentType = r.ContentType,
                                                                                 Data = r.Data,
                                                                                 FileName = r.FileName,
                                                                                 Id = t.Id,
                                                                                 QuestionId = r.QuestionId,
                                                                                 ImagePath = r.ImagePath,
                                                                                 TemplateId = template.Id
                                                                             }).Distinct().ToList(),
                                                  }).Distinct().ToList(),
                                 }).Distinct().ToList(),


            };

            return templateUI;
        }
        public ServiceRequestsDTO ConvertQuickOnlineAssessmentToBLL(QuickOnlineAssessmentViewModel model)
        {
            ServiceRequestsDTO dto = new ServiceRequestsDTO();
            if (model == null)
            {
                return dto;
            }
            dto = new ServiceRequestsDTO()
            {
                CreatedBy = model.CreatedBy,
                CreatedDate = DateTime.Now,
                ServiceName = model.ServiceName,
                ServicePaymentType = model.ServicePaymentType,
                ServiceRequestStatus = model.ServiceRequestStatus,
                ServiceType = model.ServiceType,
                UserID = model.UserName,
                Id = model.Id,
                BaseQuestions = (from e in model.BaseQuestions.Where(x => x.Id > 0)
                                 select new BaseQuestionsDetailsDTO()
                                 {
                                     BaseQuestionNameAr = e.BaseQuestionNameAr,
                                     BaseQuestionNameEn = e.BaseQuestionNameEn,
                                     BaseQuestionNumberAr = e.BaseClauseNumberAr,
                                     BaseQuestionNumberEn = e.BaseClauseNumberEn,
                                     baseTemplateId = e.baseTemplateId,
                                     Id = e.Id,
                                     clauseSystemNumber = e.BaseClauseSystemNumber,
                                     CreatedBy = model.UserName,
                                     CreatedDate = DateTime.Now,
                                     IsMandatory = e.IsMandatory,
                                     questions = (from r in e.Questions.Where(x => x.Id > 0)
                                                  select new QuestionsDetailsDTO()
                                                  {
                                                      Id = r.Id,
                                                      CreatedBy = model.UserName,
                                                      CreatedDate = DateTime.Now,
                                                      IsMandatory = r.IsMandatory,
                                                      NameAr = r.QuestionAr,
                                                      NameEn = r.QuestionEn,
                                                      NumberAr = r.clauseNumberAr,
                                                      NumberEn = r.clauseNumberEn,
                                                      ComplianceLevelValue = Convert.ToInt32(r.ComplianceLevelId),
                                                  }).Distinct().ToList(),
                                 }).Distinct().ToList(),
            };

            return dto;
        }
        public QuickOnlineAssessmentResultViewModel ConvertQuickOnlineAssessmentResultToWeb(QuickOnlineAssessmentResultDTO dto)
        {
            QuickOnlineAssessmentResultViewModel model = new QuickOnlineAssessmentResultViewModel();
            if (dto == null)
            {
                return model;
            }
            model = new QuickOnlineAssessmentResultViewModel()
            {
                CreatedBy = dto.CreatedBy,
                CreatedDate = dto.CreatedDate,
                Id = dto.Id,
                ImplementationPeriodAccurateExpectedTime = dto.ImplementationPeriodAccurateExpectedTime,
                ImplementationPeriodTime = dto.ImplementationPeriodTime,
                IsArchived = dto.IsArchived,
                IsDeleted = dto.IsDeleted,
                IsUpdated = dto.IsUpdated,
                QuestionnaireAccurateComplianceResult = Convert.ToInt32(dto.QuestionnaireAccurateComplianceResult),
                QuestionnaireComplianceResult = dto.QuestionnaireComplianceResult,
            };
            return model;
        }
        public List<ServiceRequestViewModel> ConvertUserServicesToWeb(List<UserServicesDTO> services, Culture cul)
        {
            List<ServiceRequestViewModel> servicesList = new List<ServiceRequestViewModel>();
            if (services == null)
            {
                return servicesList;
            }
            foreach (var service in services)
            {
                var newTemplate = new ServiceRequestViewModel()
                {
                    Id = service.Id,
                    PaymentType = _LookupsBusinessLogic.GetLookupByLookupId(service.ServicePaymentType, cul).Value,
                    ServiceStatus = _LookupsBusinessLogic.GetLookupByLookupId(service.ServiceRequestStatus, cul).Value,
                    ServiceRequestType = _LookupsBusinessLogic.GetLookupByLookupId(service.ServiceType, cul).Value,
                    UserId = service.UserID,
                    CreatedBy = service.CreatedBy,
                    ServiceType = service.ServiceType,
                    ServicePaymentType = service.ServicePaymentType,
                    ServiceRequestStatus = service.ServiceRequestStatus,
                    CreatedDate = service.CreatedDate,
                    LastUpdateBy = service.LastUpdateBy,
                    LastUpdateDate = service.LastUpdateDate,
                    ServiceName = service.ServiceName,
                    AssessmentResults = (from e in service.AssessmentResults.Where(u => u.Id > 0)
                                         select new QuickOnlineAssessmentResultViewModel()
                                         {
                                             Id =e.Id,
                                             ImplementationPeriodAccurateExpectedTime=e.ImplementationPeriodAccurateExpectedTime,
                                             ImplementationPeriodTime=e.ImplementationPeriodTime,
                                             IsArchived=e.IsArchived,
                                             IsDeleted=e.IsDeleted,
                                             IsUpdated=e.IsUpdated,
                                             ServiceRequestId=service.Id,
                                             QuestionnaireAccurateComplianceResult=Convert.ToInt32(e.QuestionnaireAccurateComplianceResult),
                                             QuestionnaireComplianceResult=e.QuestionnaireComplianceResult
                    }).Distinct().ToList(),
                };
                servicesList.Add(newTemplate);
            }
            return servicesList;


        }

    }
}