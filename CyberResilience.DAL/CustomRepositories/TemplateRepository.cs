using CyberResilience.Common.DTOs.Admin;
using CyberResilience.Common.DTOs.Admin.QuestionnairesDTO;
using CyberResilience.Common.DTOs.Attachment;
using CyberResilience.Common.Utilities;
using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL.CustomRepositories
{
    public class TemplateRepository : Repository<Template>
    {
        public TemplateRepository(UnitOfWork uow) : base(uow) { }
        public bool AddTemplate(TemplateDTO dto)
        {
            try
            {
                var record = new Template()
                {
                    TemplateNameAr = dto.TemplateNameAr,
                    TemplateNameEn = dto.TemplateNameEn,
                    TemplateSubType = dto.TemplateSubType,
                    TemplateType = dto.TemplateType,
                };

                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddTemplate", "An error occurred while trying to create Template Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return false;
            }
        }
        public List<TemplateDTO> GetAllTemplates()
        {
            var templates = new List<TemplateDTO>();
            try
            {
                templates = GetQuerable(x => x.Id >= 1).Include(x => x.BaseQuestionsDetails).Include(x => x.Attachments).Select(u => new TemplateDTO()
                {
                    Id = u.Id,
                    TemplateNameAr = u.TemplateNameAr,
                    TemplateNameEn = u.TemplateNameEn,
                    TemplateSubType = u.TemplateSubType,
                    TemplateType = u.TemplateType,

                    baseQuestions=(from d in u.BaseQuestionsDetails select new BaseQuestionsDetailsDTO() {
                         Id=d.Id,
                         BaseQuestionNameAr=d.BaseClauseNameAr,
                         BaseQuestionNameEn=d.BaseClauseNameEn,
                         BaseQuestionNumberAr=d.BaseClauseNumberAr,
                         BaseQuestionNumberEn=d.BaseClauseNumberEn,
                         IsMandatory=d.IsMandatory
                    }).Distinct().ToList(),

                    attachments=(from d in u.Attachments select new AttachmentDTO()
                    {
                        AttachmentID=d.AttachmentID,
                        AttachmentId=d.AttachmentID,
                        Caption=d.caption,
                        ContentType=d.caption,
                        Data=d.data,
                        FileName=d.fileName,
                        Id=d.AttachmentID,
                        TemplateId=d.TemplateID,
                    }).Distinct().ToList(),

                }).ToList();

                return templates;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetAllTemplates", "An error occurred while trying to get Templates Records - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }


        public List<TemplateDTO> GetTemplatesDropDownData()
        {
            var templates = new List<TemplateDTO>();
            try
            {
                templates = GetQuerable(x => x.Id >= 1).Select(u => new TemplateDTO()
                {
                    Id = u.Id,
                    TemplateNameAr = u.TemplateNameAr,
                    TemplateNameEn = u.TemplateNameEn,
                    TemplateSubType=u.TemplateSubType,
                    TemplateType=u.TemplateType
                }).ToList();
                return templates;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetTemplatesDropDownData", "An error occurred while trying to get Templates in drop down Records - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }

        public TemplateDTO GetTemplate(int TemplateId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == TemplateId)
                    .Include(x => x.BaseQuestionsDetails)
                    .Include(x => x.Attachments).Select(u => new TemplateDTO()
                {
                    Id = u.Id,
                    TemplateNameAr = u.TemplateNameAr,
                    TemplateNameEn = u.TemplateNameEn,
                    TemplateSubType = u.TemplateSubType,
                    TemplateType = u.TemplateType,
                    baseQuestions = (from d in u.BaseQuestionsDetails
                                     select new BaseQuestionsDetailsDTO()
                                     {
                                         Id = d.Id,
                                         BaseQuestionNameAr = d.BaseClauseNameAr,
                                         BaseQuestionNameEn = d.BaseClauseNameEn,
                                         BaseQuestionNumberAr = d.BaseClauseNumberAr,
                                         BaseQuestionNumberEn = d.BaseClauseNumberEn,
                                         IsMandatory = d.IsMandatory,
                                         baseTemplateId=u.Id,
                                         questions=(from j in d.QuestionsDetails select new QuestionsDetailsDTO() {
                                             NameAr=j.clauseNameAr,
                                             NameEn=j.clauseNameEn,
                                             Id=j.Id,
                                             IsMandatory=j.IsMandatory,
                                             NumberAr=j.clauseNumberAr,
                                             NumberEn=j.clauseNumberEn,
                                             QuestionsAttachments= (from z in j.QuestionsDetailsAttachments
                                                                    select new QuestionAttachmentsDTO()
                                                                    {
                                                                        AttachmentID = z.AttachmentID,
                                                                        AttachmentId = z.AttachmentID,
                                                                        Caption = z.caption,
                                                                        ContentType = z.caption,
                                                                        Data = z.data,
                                                                        FileName = z.fileName,
                                                                        Id = z.AttachmentID,
                                                                        QuestionId = z.QuestionDetailsID,
                                                                    }).ToList(),
                                         }).ToList(),
                                     }).ToList(),
                    attachments = (from d in u.Attachments
                                   select new AttachmentDTO()
                                   {
                                       AttachmentID = d.AttachmentID,
                                       AttachmentId = d.AttachmentID,
                                       Caption = d.caption,
                                       ContentType = d.caption,
                                       Data = d.data,
                                       FileName = d.fileName,
                                       Id = d.AttachmentID,
                                       TemplateId = d.TemplateID,
                                   }).Distinct().ToList(),

                }).FirstOrDefault();

                return record;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Template ", "An error occurred while trying to Get Template record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return null;
            }
        }
        public bool EditTemplate(TemplateDTO dto)
        {
            try
            {
                var record = GetQuerable(x => x.Id == dto.Id).FirstOrDefault();
                record.TemplateNameAr = dto.TemplateNameAr;
                record.TemplateNameEn = dto.TemplateNameEn;
                record.TemplateSubType = dto.TemplateSubType;
                record.TemplateType = dto.TemplateType;
                Update(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Template ", "An error occurred while trying to Update Template record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteTemplate(int TemplateId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == TemplateId).FirstOrDefault();
                if (record != null)
                {
                    var SubRepo = _uow.Attachments;
                    if (SubRepo.DeleteTemplateAttachments(record.Id) == true)
                    {
                        Delete(record);
                        _uow.Save();
                        return true;
                    }
                    else
                    {
                        _uow.Rollback();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Template ", "An error occurred while trying to Delete Template record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
    }
}
