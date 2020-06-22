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
    public class QuestionsDetailRepository : Repository<QuestionsDetail>
    {
        public QuestionsDetailRepository(UnitOfWork uow) : base(uow) { }
        public bool AddQuestions(QuestionsDetailsDTO dto)
        {
            try
            {
                var record = new QuestionsDetail()
                {
                    BaseQuestionDetailsId = dto.BaseQuestionDetailsId,
                    clauseNameAr = dto.clauseNameAr,
                    clauseNameEn = dto.clauseNameEn,
                    clauseNumberAr = dto.clauseNumberAr,
                    clauseNumberEn = dto.clauseNumberEn,
                    Id = dto.Id,
                    CreatedBy = dto.CreatedBy,
                    CreatedDate = dto.CreatedDate,
                };

                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddQuestion", "An error occurred while trying to create Question Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public List<QuestionsDetailsDTO> GetAllQuestions()
        {
            var Questions = new List<QuestionsDetailsDTO>();
            try
            {
                Questions = GetQuerable(x => x.Id >= 1).Select(u => new QuestionsDetailsDTO()
                {
                  Id=u.Id,
                  CreatedDate=u.CreatedDate,
                  CreatedBy=u.CreatedBy,
                  BaseQuestionDetailsId=u.BaseQuestionDetailsId,
                  clauseNameAr=u.clauseNameAr,
                  clauseNameEn=u.clauseNameEn,
                  clauseNumberAr=u.clauseNumberAr,
                  clauseNumberEn=u.clauseNumberEn,
                  
                }).ToList();

                return Questions;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetAllQuestions", "An error occurred while trying to get Questions Records - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }
        public QuestionsDetailsDTO GetQuestion(int QuestionId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == QuestionId).Select(u => new QuestionsDetailsDTO()
                {
                    Id = u.Id,
                    CreatedDate = u.CreatedDate,
                    CreatedBy = u.CreatedBy,
                    BaseQuestionDetailsId = u.BaseQuestionDetailsId,
                    clauseNameAr = u.clauseNameAr,
                    clauseNameEn = u.clauseNameEn,
                    clauseNumberAr = u.clauseNumberAr,
                    clauseNumberEn = u.clauseNumberEn,
                }).FirstOrDefault();

                return record;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Question ", "An error occurred while trying to Get Question record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return null;
            }
        }
        public QuestionsDetailsDTO GetBaseQuestionToAddQuestion(int BaseQuestionId)
        {
            try
            {
                var record = GetQuerable(x => x.BaseQuestionDetailsId >= BaseQuestionId).Include(x => x.BaseQuestionsDetail).Select(u => new QuestionsDetailsDTO()
                {
                    BaseQuestionDetailsId = u.BaseQuestionsDetail.Id,
                    BaseQuestionAr=u.BaseQuestionsDetail.BaseClauseNameAr,
                    BaseQuestionEn=u.BaseQuestionsDetail.BaseClauseNameEn
                }).FirstOrDefault();
                return record;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetBaseQuestionToAddQuestion ", "An error occurred while trying to GetBaseQuestionToAddQuestion record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return null;
            }
        }
        public bool EditQuestion(QuestionsDetailsDTO dto)
        {
            try
            {
                var record = GetQuerable(x => x.Id == dto.Id).FirstOrDefault();
                record.BaseQuestionDetailsId = dto.BaseQuestionDetailsId;
                record.CreatedBy = dto.CreatedBy;
                record.CreatedDate = dto.CreatedDate;
                record.clauseNameAr = dto.clauseNameAr;
                record.clauseNameEn = dto.clauseNameEn;
                record.clauseNumberAr = dto.clauseNumberAr;
                record.clauseNameEn = dto.clauseNumberEn;
                record.Id = dto.Id;
                Update(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Question ", "An error occurred while trying to Update Question record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteQuestion(int QuestionId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == QuestionId).FirstOrDefault();
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
                ex.Data.Add("Question ", "An error occurred while trying to Delete Question record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public List<QuestionsDetailsDTO> GetQuestionsDropDownData()
        {
            var Questions = new List<QuestionsDetailsDTO>();
            try
            {
                Questions = GetQuerable(x => x.Id >= 1).Select(u => new QuestionsDetailsDTO()
                {
                    Id = u.Id,
                    CreatedDate = u.CreatedDate,
                    CreatedBy = u.CreatedBy,
                    BaseQuestionDetailsId = u.BaseQuestionDetailsId,
                    clauseNameAr = u.clauseNameAr,
                    clauseNameEn = u.clauseNameEn,
                    clauseNumberAr = u.clauseNumberAr,
                    clauseNumberEn = u.clauseNumberEn,
                }).ToList();
                return Questions;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetQuestionsDropDownData", "An error occurred while trying to get Questions in drop down Records - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }
    }
}
