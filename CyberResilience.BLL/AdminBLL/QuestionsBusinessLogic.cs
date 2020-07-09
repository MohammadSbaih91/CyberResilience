using CyberResilience.Common.DTOs.Admin.QuestionnairesDTO;
using CyberResilience.Common.Utilities;
using CyberResilience.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.BLL.AdminBLL
{
    public class QuestionsBusinessLogic
    {
        public int AddQuestions(QuestionsDetailsDTO dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var baseQuestionId = uow.Questions.AddQuestions(dto);
                    if (baseQuestionId > 0)
                    {
                        int TemplateId = uow.BaseQuestions.GetTemplateIdUsingBaseQuestionId(baseQuestionId);
                        if (TemplateId > 0)
                        {
                            return TemplateId;
                        }
                        else
                        {
                            return TemplateId;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("AddQuestion", "An error occurred while trying to create Question Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return 0;
                }
            }
        }
        public List<QuestionsDetailsDTO> GetAllQuestions()
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var Questions = uow.Questions.GetAllQuestions();
                    if (Questions != null)
                    {
                        return Questions;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetAllQuestions", "An error occurred while trying to get all Questions Records - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public QuestionsDetailsDTO GetQuestion(int QuestionId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var Questions = uow.Questions.GetQuestion(QuestionId);
                    if (Questions != null)
                    {
                        return Questions;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetQuestion", "An error occurred while trying to get  Question Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public bool EditQuestion(QuestionsDetailsDTO dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var Questions = uow.Questions.EditQuestion(dto);
                    if (Questions != false)
                    {
                        return Questions;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("EditQuestion", "An error occurred while trying to edit Question Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public bool DeleteQuestion(int QuestionId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var Questions = uow.Questions.DeleteQuestion(QuestionId);
                    if (Questions != false)
                    {
                        return Questions;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("DeleteQuestion", "An error occurred while trying to delete Question Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }

        public List<QuestionsDetailsDTO> GetQuestionsDropDownData()
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var Questions = uow.Questions.GetQuestionsDropDownData();
                    if (Questions != null)
                    {
                        //QuestionsMapper.
                        return Questions;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetQuestionsDropDownData", "An error occurred while trying to get all Questions in drop down Records - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }


        public int GetBaseQuestionIdPerQuestionId(int QuestionId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var Questions = uow.Questions.GetBaseQuestionIdPerQuestionId(QuestionId);
                    if (Questions > 0 )
                    {
                        return Questions;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("DeleteQuestion", "An error occurred while trying to delete Question Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return 0;
                }
            }

        }
    }
}
