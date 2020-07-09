using CyberResilience.Area.Admin.Models;
using CyberResilience.BLL.LookupsBusinessLogic;
using CyberResilience.Common.DTOs.Admin;
using CyberResilience.Common.DTOs.Admin.QuestionnairesDTO;
using CyberResilience.Common.DTOs.Attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.Mapper.WebMapper
{
    public class TemplatesMapper
    {
        private LookupsBusinessLogic _LookupsBusinessLogic;

        public TemplatesMapper()
        {
            _LookupsBusinessLogic = new LookupsBusinessLogic();
        }

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
                    TemplateType = template.TemplateType,
                    IsEmptyQuestions = template.WithNoQuestions,
                    IsEmptyAttachments = template.WithNoAttachments,
                    TemplateTypeString= _LookupsBusinessLogic.GetLookupByID(template.TemplateType).Value,
                    TemplateSubTypeString= _LookupsBusinessLogic.GetLookupByID(template.TemplateSubType).Value,
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
                TemplateType = template.TemplateType,
                IsEmptyQuestions = template.WithNoQuestions,
                IsEmptyAttachments = template.WithNoAttachments
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
                    BaseClauseNameAr = basequestion.BaseQuestionNameAr,
                    BaseClauseNameEn = basequestion.BaseQuestionNameEn,
                    BaseClauseNumberAr = basequestion.BaseQuestionNumberAr,
                    BaseClauseNumberEn = basequestion.BaseQuestionNumberEn,
                    baseTemplateId = basequestion.baseTemplateId,
                    BaseQuestionNameAr = basequestion.BaseQuestionNameAr,
                    BaseQuestionNameEn = basequestion.BaseQuestionNameEn,
                    Id = basequestion.Id,
                    CreatedBy = basequestion.CreatedBy,
                    CreatedDate = basequestion.CreatedDate,
                    Questions = (from e in basequestion.questions.Where(u => u.Id >= 0)
                                 select new QuestionsViewModel()
                                 {
                                     BaseQuestionDetailsId = basequestion.Id,
                                     clauseNameAr = e.NameAr,
                                     Id = e.Id,
                                     clauseNameEn = e.NameEn,
                                     clauseNumberAr = e.NumberAr,
                                     QuestionAr = e.NameAr,
                                     QuestionEn = e.NameEn,
                                     clauseNumberEn = e.NumberEn,
                                     clauseSystemNumber = e.clauseSystemNumber,
                                     CreatedBy = e.CreatedBy,
                                     CreatedDate = e.CreatedDate,
                                     IsMandatory = e.IsMandatory.HasValue?e.IsMandatory.Value:false,
                                     questionAttachments=(from t in e.QuestionsAttachments.Where(u=>u.Id>0)select new AttachmentViewModel() {
                                         AttachmentID = t.AttachmentID,
                                         AttachmentId = t.AttachmentId,
                                         Caption = t.Caption,
                                         ContentType = t.ContentType,
                                         Data = t.Data,
                                         FileName = t.FileName,
                                         Id = t.Id,
                                         QuestionId = t.QuestionId,
                                         ImagePath = t.ImagePath,
                                         TemplateId=basequestion.baseTemplateId
                                     }).Distinct().ToList(),
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
                BaseClauseNameAr = basedto.BaseQuestionNameAr,
                BaseClauseNameEn = basedto.BaseQuestionNameEn,
                BaseClauseNumberAr = basedto.BaseQuestionNumberAr,
                BaseClauseNumberEn = basedto.BaseQuestionNumberEn,
                baseTemplateId = basedto.baseTemplateId,
                BaseQuestionNameAr = basedto.BaseQuestionNameAr,
                BaseQuestionNameEn = basedto.BaseQuestionNameEn,
                Id = basedto.Id,
                CreatedBy = basedto.CreatedBy,
                Questions = (from e in basedto.questions.Where(u => u.Id >= 0)
                             select new QuestionsViewModel()
                             {
                                 BaseQuestionDetailsId = basedto.Id,
                                 clauseNameAr = e.NameAr,
                                 Id = e.Id,
                                 clauseNameEn = e.NameEn,
                                 clauseNumberAr = e.NumberAr,
                                 QuestionAr = e.NameAr,
                                 QuestionEn = e.NameEn,
                                 clauseNumberEn = e.NumberEn,
                                 clauseSystemNumber = e.clauseSystemNumber,
                                 CreatedBy = e.CreatedBy,
                                 CreatedDate = e.CreatedDate,
                                 IsMandatory = e.IsMandatory.HasValue ? e.IsMandatory.Value : false,
                                 questionAttachments = (from t in e.QuestionsAttachments.Where(u => u.Id > 0)
                                                        select new AttachmentViewModel()
                                                        {
                                                            AttachmentID = t.AttachmentID,
                                                            AttachmentId = t.AttachmentId,
                                                            Caption = t.Caption,
                                                            ContentType = t.ContentType,
                                                            Data = t.Data,
                                                            FileName = t.FileName,
                                                            Id = t.Id,
                                                            QuestionId = t.QuestionId,
                                                            ImagePath = t.ImagePath,
                                                            TemplateId = basedto.baseTemplateId
                                                        }).Distinct().ToList(),


                             }).Distinct().ToList(),
                CreatedDate = basedto.CreatedDate,
            };


            return BaseQuestionsUI;
        }
        public BaseQuestionsDetailsDTO ConvertBaseQuestionsToBLL(BaseQuestionsViewModel basequestionsModel)
        {
            BaseQuestionsDetailsDTO BaseQuestionsDto = new BaseQuestionsDetailsDTO();
            if (basequestionsModel == null)
            {
                return BaseQuestionsDto;
            }
            BaseQuestionsDto = new BaseQuestionsDetailsDTO()
            {
                baseTemplateId = basequestionsModel.baseTemplateId,
                BaseQuestionNameAr = basequestionsModel.BaseQuestionNameAr,
                BaseQuestionNameEn = basequestionsModel.BaseQuestionNameEn,
                BaseQuestionNumberAr = basequestionsModel.BaseClauseNumberAr,
                BaseQuestionNumberEn = basequestionsModel.BaseClauseNumberEn,
                CreatedDate = DateTime.Now,
                CreatedBy = "Admin",
                Id = basequestionsModel.Id,
                //questions =(from e in basequestionsModel.Questions.Where(u=>u.Id>0)
                //           select new QuestionsDetailsDTO() {
                //               Id=e.Id,
                //               CreatedBy="Admin", 
                //               CreatedDate=DateTime.Now,
                //               IsMandatory=e.IsMandatory,
                //               LastUpdateBy="Admin",
                //               LastUpdateDate=DateTime.Now,
                //               NameAr=e.clauseNameAr,
                //               NameEn=e.clauseNameEn,
                //               QuestionsAttachments = (from t in e.questionAttachments.Where(u => u.Id > 0)
                //                                      select new QuestionAttachmentsDTO()
                //                                      {
                //                                          AttachmentID = t.AttachmentID,
                //                                          AttachmentId = t.AttachmentId,
                //                                          Caption = t.Caption,
                //                                          ContentType = t.ContentType,
                //                                          Data = t.Data,
                //                                          FileName = t.FileName,
                //                                          Id = t.Id,
                //                                          QuestionId = t.QuestionId,
                //                                          ImagePath = t.ImagePath,
                //                                      }).Distinct().ToList(),


                //           }).Distinct().ToList(),
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
                    BaseQuestionDetailsId = question.BaseQuestionDetailsId,
                    clauseNameAr = question.NameAr,
                    clauseNameEn = question.NameEn,
                    clauseNumberAr = question.NumberAr,
                    clauseNumberEn = question.NumberEn,
                    clauseSystemNumber = question.clauseSystemNumber,

                };
                QuestionsList.Add(newQuestion);
            }
            return QuestionsList;
        }
        public QuestionsViewModel ConvertQuestionToWeb(QuestionsDetailsDTO questiondto)
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
                clauseNameAr = questiondto.NameAr,
                clauseNameEn = questiondto.NameEn,
                clauseNumberAr = questiondto.NumberAr,
                clauseNumberEn = questiondto.NumberEn,
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
                NameAr = questionDto.clauseNameAr,
                NameEn = questionDto.clauseNameEn,
                NumberAr = questionDto.clauseNumberAr,
                NumberEn = questionDto.clauseNumberEn,
                clauseSystemNumber = questionDto.clauseSystemNumber,
                IsMandatory = questionDto.IsMandatory,
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
                BaseQuestionDetailsId = basequestionsDto.Id,
                BaseQuestionAr = basequestionsDto.BaseQuestionNameAr,
                BaseQuestionEn = basequestionsDto.BaseQuestionNameEn
            };
            return QuestionsUI;
        }


        #endregion



        #region Attahcments 
        public List<AttachmentViewModel> ConvertAttachmentsToWeb(List<AttachmentDTO> attachmetnsdto)
        {
            List<AttachmentViewModel> AttachmentList = new List<AttachmentViewModel>();
            if (attachmetnsdto == null)
            {
                return AttachmentList;
            }
            foreach (var template in attachmetnsdto)
            {
                var newTemplate = new AttachmentViewModel()
                {
                    AttachmentID = template.AttachmentID,
                    AttachmentId = template.AttachmentId,
                    Caption = template.Caption,
                    ContentType = template.ContentType,
                    Data = template.Data,
                    FileName = template.FileName,
                    Id = template.Id,
                    TemplateId = template.TemplateId,
                    ImagePath = template.ImagePath
                };
                AttachmentList.Add(newTemplate);
            }
            return AttachmentList;
        }

        public AttachmentViewModel ConvertAttachmentToWeb(AttachmentDTO attachmetnsdto)
        {
            AttachmentViewModel AttachmentModel = new AttachmentViewModel();
            if (attachmetnsdto == null)
            {
                return AttachmentModel;
            }
            AttachmentModel.AttachmentID = attachmetnsdto.AttachmentID;
            AttachmentModel.AttachmentId = attachmetnsdto.AttachmentId;
            AttachmentModel.Caption = attachmetnsdto.Caption;
            AttachmentModel.ContentType = attachmetnsdto.ContentType;
            AttachmentModel.Data = attachmetnsdto.Data;
            AttachmentModel.FileName = attachmetnsdto.FileName;
            AttachmentModel.Id = attachmetnsdto.Id;
            AttachmentModel.TemplateId = attachmetnsdto.TemplateId;
            AttachmentModel.ImagePath = attachmetnsdto.ImagePath;

            return AttachmentModel;
        }
        #endregion
    }
}