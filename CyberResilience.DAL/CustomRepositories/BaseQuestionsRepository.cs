using CyberResilience.Common.DTOs.Admin.QuestionnairesDTO;
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
                   BaseClauseNameAr=dto.clauseNameAr,
                   BaseClauseNameEn=dto.clauseNameEn,
                   CreatedBy=dto.CreatedBy,
                   Id=dto.Id,
                   TemplateId=dto.baseTemplateId,
                   CreatedDate=dto.CreatedDate,
                   BaseClauseNumberAr=dto.clauseNumberAr,
                   BaseClauseNumberEn=dto.clauseNumberEn
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
                    baseTemplateId=u.TemplateId,
                    Id=u.Id,
                    clauseNameAr=u.BaseClauseNameAr,
                    clauseNameEn=u.BaseClauseNameEn,
                    clauseNumberAr=u.BaseClauseNumberAr,
                    clauseNumberEn=u.BaseClauseNumberEn,
                    CreatedBy=u.CreatedBy,
                    CreatedDate=u.CreatedDate,
                    questions=(from d in u.QuestionsDetails
                               select new QuestionsDetailsDTO()
                               {
                                   BaseQuestionDetailsId=u.Id,
                                   Id=d.Id,
                                   clauseNameAr=d.clauseNameAr,
                                   clauseNameEn=d.clauseNameEn,
                                   clauseNumberAr=d.clauseNumberAr,
                                   clauseNumberEn=d.clauseNumberEn,
                                   clauseSystemNumber=d.clauseSystemNumber,
                                   CreatedBy=d.CreatedBy,
                                   CreatedDate=d.CreatedDate,
                                   IsMandatory=d.IsMandatory,
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
                var record = GetQuerable(x => x.Id == BaseQuestionId).Select(u => new BaseQuestionsDetailsDTO()
                {
                    baseTemplateId=u.TemplateId,
                    Id=u.Id,
                    clauseNameAr=u.BaseClauseNameAr,
                    clauseNameEn=u.BaseClauseNameEn,
                    clauseNumberAr=u.BaseClauseNumberAr,
                    clauseNumberEn=u.BaseClauseNumberEn,
                    CreatedBy=u.CreatedBy,
                    CreatedDate=u.CreatedDate,
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
                var record = GetQuerable(x => x.Id == dto.Id).FirstOrDefault();
                record.CreatedDate = dto.CreatedDate;
                record.CreatedBy = dto.CreatedBy;
                record.BaseClauseNameAr = dto.clauseNameAr;
                record.BaseClauseNameEn = dto.clauseNameEn;
                record.BaseClauseNumberAr = dto.clauseNumberAr;
                record.BaseClauseNumberEn = dto.clauseNumberEn;
                record.TemplateId = dto.baseTemplateId;
                record.Id = dto.Id;
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
                var record = GetQuerable(x => x.Id == BaseQuestionId).FirstOrDefault();
                if (record != null)
                {
                    Delete(record);
                    _uow.Save();
                    return true;
                }
                else
                {
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
                    baseTemplateId = u.TemplateId,
                    Id=u.Id,
                    clauseNameAr=u.BaseClauseNameAr,
                    clauseNameEn=u.BaseClauseNameEn,
                    clauseNumberAr=u.BaseClauseNumberAr,
                    clauseNumberEn=u.BaseClauseNumberEn,
                    CreatedBy=u.CreatedBy,
                    CreatedDate=u.CreatedDate,
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
    }
}
