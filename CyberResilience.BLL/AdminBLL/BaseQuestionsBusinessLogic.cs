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
   public class BaseQuestionsBusinessLogic
    {
        public bool AddBaseQuestions(BaseQuestionsDetailsDTO dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var BaseQuestionAdded = uow.BaseQuestions.AddBaseQuestions(dto);
                    if (BaseQuestionAdded != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("AddBaseQuestion", "An error occurred while trying to create BaseQuestion Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public List<BaseQuestionsDetailsDTO> GetAllBaseQuestions(int TemplateId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var BaseQuestions = uow.BaseQuestions.GetAllBaseQuestions(TemplateId);
                    if (BaseQuestions != null)
                    {
                        return BaseQuestions;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetAllBaseQuestions", "An error occurred while trying to get all BaseQuestions Records - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public BaseQuestionsDetailsDTO GetBaseQuestion(int BaseQuestionId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var BaseQuestions = uow.BaseQuestions.GetBaseQuestion(BaseQuestionId);
                    if (BaseQuestions != null)
                    {
                        return BaseQuestions;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetBaseQuestion", "An error occurred while trying to get  BaseQuestion Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public bool EditBaseQuestion(BaseQuestionsDetailsDTO dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var BaseQuestions = uow.BaseQuestions.EditBaseQuestion(dto);
                    if (BaseQuestions != false)
                    {
                        return BaseQuestions;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("EditBaseQuestion", "An error occurred while trying to edit BaseQuestion Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public bool DeleteBaseQuestion(int BaseQuestionId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var BaseQuestions = uow.BaseQuestions.DeleteBaseQuestion(BaseQuestionId);
                    if (BaseQuestions != false)
                    {
                        return BaseQuestions;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("DeleteBaseQuestion", "An error occurred while trying to delete BaseQuestion Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public List<BaseQuestionsDetailsDTO> GetBaseQuestionsDropDownData()
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var BaseQuestions = uow.BaseQuestions.GetBaseQuestionsDropDownData();
                    if (BaseQuestions != null)
                    {
                        //BaseQuestionsMapper.
                        return BaseQuestions;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetBaseQuestionsDropDownData", "An error occurred while trying to get all BaseQuestions in drop down Records - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public QuestionsDetailsDTO GetBaseQuestionToAddQuestion(int BaseQuestionId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var QuestionsBaseDetails = uow.Questions.GetBaseQuestionToAddQuestion(BaseQuestionId);
                    if (QuestionsBaseDetails != null)
                    {
                        return QuestionsBaseDetails;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetBaseQuestionToAdd", "An error occurred while trying to edit GetBaseQuestionToAdd Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }

    }
}
