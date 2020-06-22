using CyberResilience.Area.Admin.Models;
using CyberResilience.Common.DTOs.Admin;
using CyberResilience.Common.DTOs.Admin.QuestionnairesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.Mapper.WebMapper
{
    public class TemplatesMapper
    {
        #region Templates Mapper
        public List<BaseTemplateViewModel> ConvertTemplatesToWeb(List<TemplateDTO> templates)
        {
            List<BaseTemplateViewModel> templatesList = new List<BaseTemplateViewModel>();
            if (templates == null)
            {
                return templatesList;
            }
            foreach (var template in templates)
            {
                var newTemplate = new BaseTemplateViewModel()
                {
                    Id = template.Id,
                    TemplateNameAr = template.TemplateNameAr,
                    TemplateNameEn = template.TemplateNameEn,
                    TemplateSubType = template.TemplateSubType,
                    TemplateType = template.TemplateType
                };
                templatesList.Add(newTemplate);
            }
            return templatesList;
        }
        public BaseTemplateViewModel ConvertTemplateToWeb(TemplateDTO template)
        {
            BaseTemplateViewModel templateUI = new BaseTemplateViewModel();
            if (templateUI == null)
            {
                return templateUI;
            }
            templateUI = new BaseTemplateViewModel()
            {
                Id = template.Id,
                TemplateNameAr = template.TemplateNameAr,
                TemplateNameEn = template.TemplateNameEn,
                TemplateSubType = template.TemplateSubType,
                TemplateType = template.TemplateType
            };

            return templateUI;
        }
        public TemplateDTO ConvertTemplateToBLL(BaseTemplateViewModel template)
        {
            TemplateDTO templateDto = new TemplateDTO();
            if (template == null)
            {
                return templateDto;
            }
            templateDto = new TemplateDTO()
            {
                Id = template.Id,
                TemplateNameAr = template.TemplateNameAr,
                TemplateNameEn = template.TemplateNameEn,
                TemplateSubType = template.TemplateSubType,
                TemplateType = template.TemplateType
            };
            return templateDto;
        }


        #endregion
        #region Base Questions Mapper 
        public List<BaseQuestionsViewModel> ConvertBaseQuestionsToWeb(List<BaseQuestionsDetailsDTO> BaseQuestions)
        {
            List<BaseQuestionsViewModel> BaseQuestionsList = new List<BaseQuestionsViewModel>();
            if (BaseQuestions == null)
            {
                return BaseQuestionsList;
            }
            foreach (var basequestion in BaseQuestions)
            {
                var newBaseQuestion = new BaseQuestionsViewModel()
                {
                  BaseClauseNameAr=basequestion.clauseNameAr,
                  BaseClauseNameEn=basequestion.clauseNameEn,
                  BaseClauseNumberAr=basequestion.clauseNumberAr,
                  BaseClauseNumberEn=basequestion.clauseNumberEn,
                  baseTemplateId=basequestion.baseTemplateId,
                  BaseQuestionNameAr=basequestion.clauseNameAr,
                  BaseQuestionNameEn=basequestion.clauseNameEn,
                  Id=basequestion.Id,
                  CreatedBy=basequestion.CreatedBy,
                  CreatedDate=basequestion.CreatedDate,
                  Questions=(from e in basequestion.questions.Where(u=>u.Id>=0)
                             select new QuestionsViewModel()
                             {
                                 BaseQuestionDetailsId=basequestion.Id,
                                 clauseNameAr=e.clauseNameAr,
                                 Id=e.Id,
                                 clauseNameEn=e.clauseNameEn,
                                 clauseNumberAr=e.clauseNumberAr,
                                 QuestionAr=e.clauseNameAr,
                                 QuestionEn=e.clauseNameEn,
                                 clauseNumberEn=e.clauseNumberEn,
                                 clauseSystemNumber=e.clauseSystemNumber,
                                 CreatedBy=e.CreatedBy,
                                 CreatedDate=e.CreatedDate,
                                 IsMandatory=e.IsMandatory,
                             }).Distinct().ToList(),
                };
                BaseQuestionsList.Add(newBaseQuestion);
            }
            return BaseQuestionsList;
        }
        public BaseQuestionsViewModel ConvertBaseQuestionsToWeb(BaseQuestionsDetailsDTO basedto)
        {
            BaseQuestionsViewModel BaseQuestionsUI = new BaseQuestionsViewModel();
            if (basedto == null)
            {
                return BaseQuestionsUI;
            }
            BaseQuestionsUI = new BaseQuestionsViewModel()
            {
                BaseClauseNameAr = basedto.clauseNameAr,
                BaseClauseNameEn = basedto.clauseNameEn,
                BaseClauseNumberAr = basedto.clauseNumberAr,
                BaseClauseNumberEn = basedto.clauseNumberEn,
                baseTemplateId = basedto.baseTemplateId,
                Id = basedto.Id,
                CreatedBy = basedto.CreatedBy,
                CreatedDate = basedto.CreatedDate
            };

            return BaseQuestionsUI;
        }
        public BaseQuestionsDetailsDTO ConvertBaseQuestionsToBLL(BaseQuestionsViewModel basequestionsDto)
        {
            BaseQuestionsDetailsDTO BaseQuestionsDto = new BaseQuestionsDetailsDTO();
            if (basequestionsDto == null)
            {
                return BaseQuestionsDto;
            }
            BaseQuestionsDto = new BaseQuestionsDetailsDTO()
            {
                baseTemplateId=basequestionsDto.baseTemplateId,
                clauseNameAr=basequestionsDto.BaseClauseNameAr,
                clauseNameEn=basequestionsDto.BaseClauseNameEn,
                clauseNumberAr=basequestionsDto.BaseClauseNumberAr,
                clauseNumberEn=basequestionsDto.BaseClauseNumberEn,
                CreatedBy=basequestionsDto.CreatedBy,
                CreatedDate=basequestionsDto.CreatedDate,
                Id=basequestionsDto.Id
            };
            return BaseQuestionsDto;
        }

        #endregion
        #region Questions Mapper 
        public List<QuestionsViewModel> ConvertQuestionsToWeb(List<QuestionsDetailsDTO> Questions)
        {
            List<QuestionsViewModel> QuestionsList = new List<QuestionsViewModel>();
            if (Questions == null)
            {
                return QuestionsList;
            }
            foreach (var question in Questions)
            {
                var newQuestion = new QuestionsViewModel()
                {
                    
                    Id = question.Id,
                    CreatedBy = question.CreatedBy,
                    CreatedDate = question.CreatedDate,
                    BaseQuestionDetailsId=question.BaseQuestionDetailsId,
                    clauseNameAr=question.clauseNameAr,
                    clauseNameEn=question.clauseNameEn,
                    clauseNumberAr=question.clauseNumberAr,
                    clauseNumberEn=question.clauseNumberEn,
                    clauseSystemNumber=question.clauseSystemNumber,
                    
                };
                QuestionsList.Add(newQuestion);
            }
            return QuestionsList;
        }
        public QuestionsViewModel ConvertQuestionsToWeb(QuestionsDetailsDTO questiondto)
        {
            QuestionsViewModel QuestionsUI = new QuestionsViewModel();
            if (questiondto == null)
            {
                return QuestionsUI;
            }
            QuestionsUI = new QuestionsViewModel()
            {
                Id = questiondto.Id,
                CreatedBy = questiondto.CreatedBy,
                CreatedDate = questiondto.CreatedDate,
                BaseQuestionDetailsId = questiondto.BaseQuestionDetailsId,
                clauseNameAr = questiondto.clauseNameAr,
                clauseNameEn = questiondto.clauseNameEn,
                clauseNumberAr = questiondto.clauseNumberAr,
                clauseNumberEn = questiondto.clauseNumberEn,
                clauseSystemNumber = questiondto.clauseSystemNumber,
            };

            return QuestionsUI;
        }
        public QuestionsDetailsDTO ConvertQuestionsToBLL(QuestionsViewModel questionDto)
        {
            QuestionsDetailsDTO QuestionsDto = new QuestionsDetailsDTO();
            if (questionDto == null)
            {
                return QuestionsDto;
            }
            QuestionsDto = new QuestionsDetailsDTO()
            {
                Id = questionDto.Id,
                CreatedBy = questionDto.CreatedBy,
                CreatedDate = questionDto.CreatedDate,
                BaseQuestionDetailsId = questionDto.BaseQuestionDetailsId,
                clauseNameAr = questionDto.clauseNameAr,
                clauseNameEn = questionDto.clauseNameEn,
                clauseNumberAr = questionDto.clauseNumberAr,
                clauseNumberEn = questionDto.clauseNumberEn,
                clauseSystemNumber = questionDto.clauseSystemNumber,
            };
            return QuestionsDto;
        }
        public QuestionsViewModel ConvertAddQuestionsToWeb(BaseQuestionsDetailsDTO basequestionsDto)
        {
            QuestionsViewModel QuestionsUI = new QuestionsViewModel();
            if (basequestionsDto == null)
            {
                return QuestionsUI;
            }
            QuestionsUI = new QuestionsViewModel()
            {
               BaseQuestionDetailsId= basequestionsDto.Id,
               BaseQuestionAr= basequestionsDto.clauseNameAr,
               BaseQuestionEn= basequestionsDto.clauseNameEn
            };
            return QuestionsUI;
        }

        
        #endregion
    }
}