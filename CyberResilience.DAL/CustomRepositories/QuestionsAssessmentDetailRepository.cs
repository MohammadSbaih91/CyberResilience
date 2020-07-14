using CyberResilience.Common.Utilities;
using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL.CustomRepositories
{
    public class QuestionsAssessmentDetailRepository : Repository<QuestionsAssessmentDetail>
    {

        public QuestionsAssessmentDetailRepository(UnitOfWork uow) : base(uow) { }
        public bool AddQuestionsAssessmentDetails(List<QuestionsAssessmentDetail> AssessmentQuestions)
        {
            try
            {
                foreach (var entity in AssessmentQuestions)
                {
                    Create(entity);
                }
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddQuestionsAssessmentDetails", "An error occurred while trying to create Assessment Question Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }


        }

    }
}
