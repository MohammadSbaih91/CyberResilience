using CyberResilience.Base;
using CyberResilience.BLL.LookupsBusinessLogic;
using CyberResilience.Common.DTOs.Admin;
using CyberResilience.Common.DTOs.ServiceRequestsDTO;
using CyberResilience.Models.FreeServicesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.Mapper.WebMapper
{
    public class FreeServicesMapper: BaseController
    {
        private LookupCategoryBusinessLogic _LookupCategoryBusinessLogic;

        public FreeServicesMapper()
        {
            _LookupCategoryBusinessLogic = new LookupCategoryBusinessLogic();
        }
        public QuickOnlineAssessmentViewModel ConvertQuickOnlineAssessmentToWeb(TemplateDTO template)
        {
            QuickOnlineAssessmentViewModel templateUI = new QuickOnlineAssessmentViewModel();
            if (template == null)
            {
                return templateUI;
            }
            templateUI = new QuickOnlineAssessmentViewModel()
            {
                Id = template.Id,
                TemplateNameAr = template.TemplateNameAr,
                TemplateNameEn = template.TemplateNameEn,
                TemplateSubType = template.TemplateSubType,
                TemplateType = template.TemplateType,
                TemplateTypes= _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", base.CurrentCulture),
                TemplateSubTypes= _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", base.CurrentCulture),
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
                                                 BaseQuestion=(base.CurrentCulture== CyberResilience.Common.Enums.Culture.Arabic) ? e.BaseQuestionNameAr :e.BaseQuestionNameEn,
                                                 CreatedDate = e.CreatedDate,
                                                 IsMandatory = e.IsMandatory.HasValue ? e.IsMandatory.Value : false,
                                                 Questions = (from t in e.questions.Where(u => u.Id > 0)
                                                                        select new QuickOnlineAssessmentQuestionsViewModel()
                                                                        {

                                                                            BaseQuestionDetailsId = e.Id,
                                                                            Question= (base.CurrentCulture == CyberResilience.Common.Enums.Culture.Arabic) ? t.NameAr : t.NameEn,
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
                                                                            ComplianceLevel= _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ComplianceLevel", base.CurrentCulture),
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
                CreatedBy=model.CreatedBy,
                CreatedDate=DateTime.Now,
                ServiceName=model.Type,
                ServicePaymentType=model.ServicePaymentType,
                ServiceRequestStatus=model.ServiceRequestStatus,
                ServiceType=model.ServiceType,
                UserID=model.UserName,
                BaseQuestions=(from e in model.BaseQuestions.Where(x=>x.Id>0)
                               select new BaseQuestionsDetailsDTO()
                               {
                                   BaseQuestionNameAr=e.BaseQuestionNameAr,
                                   BaseQuestionNameEn=e.BaseQuestionNameEn,
                                   BaseQuestionNumberAr=e.BaseClauseNumberAr,
                                   BaseQuestionNumberEn=e.BaseClauseNumberEn,
                                   baseTemplateId=e.baseTemplateId,
                                   clauseSystemNumber=e.BaseClauseSystemNumber,
                                   CreatedBy=model.UserName,
                                   CreatedDate=DateTime.Now,
                                   IsMandatory=e.IsMandatory,
                                   questions=(from r in e.Questions.Where(x=>x.Id>0)
                                              select new QuestionsDetailsDTO()
                                              {
                                                 CreatedBy=model.UserName,
                                                 CreatedDate=DateTime.Now,
                                                 IsMandatory=r.IsMandatory,
                                                 NameAr=r.QuestionAr,
                                                 NameEn=r.QuestionEn,
                                                 NumberAr=r.clauseNumberAr,
                                                 NumberEn=r.clauseNumberEn,
                                                 ComplianceLevelValue=r.ComplianceLevelValue,
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
                CreatedBy=dto.CreatedBy,
                CreatedDate=dto.CreatedDate,
                Id=dto.Id,
                ImplementationPeriodAccurateExpectedTime=dto.ImplementationPeriodAccurateExpectedTime,
                ImplementationPeriodTime=dto.ImplementationPeriodTime,
                IsArchived=dto.IsArchived,
                IsDeleted=dto.IsDeleted,
                IsUpdated=dto.IsUpdated,
                QuestionnaireAccurateComplianceResult=dto.QuestionnaireAccurateComplianceResult,
                QuestionnaireComplianceResult=dto.QuestionnaireComplianceResult,
            };
            return model;
        }




    }
}