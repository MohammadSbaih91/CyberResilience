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
    public class BaseQuestionsRepository : Repository<BaseQuestionsDetail>
    {
        public BaseQuestionsRepository(UnitOfWork uow) : base(uow) { }

        public bool AddBaseQuestions(BaseQuestionsDetailsDTO dto)
        {
            try
            {
                var record = new BaseQuestionsDetail()
                {
                    BaseClauseNameAr = dto.BaseQuestionNameAr,
                    BaseClauseNameEn = dto.BaseQuestionNameEn,
                    CreatedBy = dto.CreatedBy,
                    Id = dto.Id,
                    TemplateId = dto.baseTemplateId,
                    CreatedDate = dto.CreatedDate,
                    BaseClauseNumberAr = dto.BaseQuestionNumberAr,
                    BaseClauseNumberEn = dto.BaseQuestionNumberEn
                };

                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddBaseQuestion", "An error occurred while trying to create BaseQuestion Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return false;
            }
        }
        public List<BaseQuestionsDetailsDTO> GetAllBaseQuestions(int TemplateId)
        {
            var BaseQuestions = new List<BaseQuestionsDetailsDTO>();
            try
            {
                BaseQuestions = GetQuerable(x => x.TemplateId >= TemplateId).Include(x => x.QuestionsDetails).Select(u => new BaseQuestionsDetailsDTO()
                {
                    baseTemplateId = u.TemplateId.Value,
                    Id = u.Id,
                    BaseQuestionNameAr = u.BaseClauseNameAr,
                    BaseQuestionNameEn = u.BaseClauseNameEn,
                    BaseQuestionNumberAr = u.BaseClauseNumberAr,
                    BaseQuestionNumberEn = u.BaseClauseNumberEn,
                    CreatedBy = u.CreatedBy,
                    CreatedDate = u.CreatedDate,
                    questions = (from d in u.QuestionsDetails
                                 select new QuestionsDetailsDTO()
                                 {
                                     BaseQuestionDetailsId = u.Id,
                                     Id = d.Id,
                                     NameAr = d.clauseNameAr,
                                     NameEn = d.clauseNameEn,
                                     clauseSystemNumber = d.clauseSystemNumber,
                                     CreatedBy = d.CreatedBy,
                                     CreatedDate = d.CreatedDate,
                                     IsMandatory = d.IsMandatory,
                                     NumberAr = d.clauseNumberAr,
                                     NumberEn = d.clauseNumberEn,
                                 }).Distinct().ToList(),
                }).ToList();
                return BaseQuestions;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetAllBaseQuestions", "An error occurred while trying to get BaseQuestions Records - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }
        public BaseQuestionsDetailsDTO GetBaseQuestion(int BaseQuestionId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == BaseQuestionId).Include(x => x.QuestionsDetails).Select(u => new BaseQuestionsDetailsDTO()
                {
                    baseTemplateId = u.TemplateId.Value,
                    Id = u.Id,
                    BaseQuestionNameAr = u.BaseClauseNameAr,
                    BaseQuestionNameEn = u.BaseClauseNameEn,
                    BaseQuestionNumberAr = u.BaseClauseNumberAr,
                    BaseQuestionNumberEn = u.BaseClauseNumberEn,
                    CreatedBy = u.CreatedBy,
                    CreatedDate = u.CreatedDate,
                    questions = (from d in u.QuestionsDetails
                                 select new QuestionsDetailsDTO()
                                 {
                                     BaseQuestionDetailsId = u.Id,
                                     Id = d.Id,
                                     NameAr = d.clauseNameAr,
                                     NameEn = d.clauseNameEn,
                                     clauseSystemNumber = d.clauseSystemNumber,
                                     CreatedBy = d.CreatedBy,
                                     CreatedDate = d.CreatedDate,
                                     IsMandatory = d.IsMandatory,
                                     NumberAr = d.clauseNumberAr,
                                     NumberEn = d.clauseNumberEn,
                                     QuestionsAttachments = (from z in d.QuestionsDetailsAttachments
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
                }).FirstOrDefault();

                return record;
            }
            catch (Exception ex)
            {
                ex.Data.Add("BaseQuestion ", "An error occurred while trying to Get BaseQuestion record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return null;
            }
        }
        public bool EditBaseQuestion(BaseQuestionsDetailsDTO dto)
        {
            try
            {
                var record = GetQuerable(x => x.Id == dto.Id).Include(x => x.QuestionsDetails).FirstOrDefault();
                record.CreatedDate = dto.CreatedDate;
                record.CreatedBy = dto.CreatedBy;
                record.BaseClauseNameAr = dto.BaseQuestionNameAr;
                record.BaseClauseNameEn = dto.BaseQuestionNameEn;
                record.BaseClauseNumberAr = dto.BaseQuestionNumberAr;
                record.BaseClauseNumberEn = dto.BaseQuestionNumberEn;
                record.TemplateId = dto.baseTemplateId;
                record.IsMandatory = dto.IsMandatory;
                record.LastUpdateBy = "Admin";
                record.LastUpdateDate = DateTime.Now;


                Update(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("BaseQuestion ", "An error occurred while trying to Update BaseQuestion record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteBaseQuestion(int BaseQuestionId)
        {
            try
            {
                var repo = _uow.Questions;
                bool isSubDelted = repo.DeleteAllBaseQuestionsDetailSubElements(BaseQuestionId);
                if (isSubDelted == true)
                {
                    var record = GetQuerable(x => x.Id == BaseQuestionId).FirstOrDefault();
                    if (record != null)
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
                    _uow.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("BaseQuestion ", "An error occurred while trying to Delete BaseQuestion record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public List<BaseQuestionsDetailsDTO> GetBaseQuestionsDropDownData()
        {
            var BaseQuestions = new List<BaseQuestionsDetailsDTO>();
            try
            {
                BaseQuestions = GetQuerable(x => x.Id >= 1).Select(u => new BaseQuestionsDetailsDTO()
                {
                    baseTemplateId = u.TemplateId.Value,
                    Id = u.Id,
                    BaseQuestionNameAr = u.BaseClauseNameAr,
                    BaseQuestionNameEn = u.BaseClauseNameEn,
                    BaseQuestionNumberAr = u.BaseClauseNumberAr,
                    BaseQuestionNumberEn = u.BaseClauseNumberEn,
                    CreatedBy = u.CreatedBy,
                    CreatedDate = u.CreatedDate,
                }).ToList();
                return BaseQuestions;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetBaseQuestionsDropDownData", "An error occurred while trying to get BaseQuestions in drop down Records - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }
        public int GetTemplateIdUsingBaseQuestionId(int BaseQuestionId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == BaseQuestionId).FirstOrDefault();
                if (record != null)
                {
                    return record.TemplateId.Value;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetTemplateIdUsingBaseQuestionId", "An error occurred while trying to GetTemplateIdUsingBaseQuestionId   - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return 0;
            }

        }
        public bool DeleteAllTemplateSubElements(int TemplateId)
        {
            try
            {
                var record = GetQuerable(x => x.TemplateId == TemplateId).ToList();
                if (record != null)
                {
                    var repo = _uow.BaseQuestions;
                    var SubRepo = _uow.Questions;
                    foreach (var i in record)
                    {
                        if (SubRepo.DeleteAllBaseQuestionsDetailSubElements(i.Id) == true)
                        {
                            repo.Delete(i);
                            _uow.Save();
                            return true;
                        }
                        else
                        {
                            _uow.Rollback();
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("DeleteAllTemplateSubElements ", "An error occurred while trying to DeleteAllTemplateSubElements record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }



    }
}
