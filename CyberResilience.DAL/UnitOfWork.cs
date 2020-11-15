using CyberResilience.Common.Utilities;
using CyberResilience.DAL.CustomRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL
{
   public class UnitOfWork : IDisposable
    {
        public readonly CyberResilience.DAL.Entities.Database _context = new CyberResilience.DAL.Entities.Database();
        private bool disposed = false;
        private DbContextTransaction _dbContextTransaction;
        public DbContext DbContext { get; private set; }

        public UnitOfWork()
        {

        }

        public UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public QuestionsDetailsAttachmentRepository QuestionAttachments
        {
            get
            {
                return new QuestionsDetailsAttachmentRepository(this);
            }
        }

        public ToolkitRepository Toolkit
        {
            get
            {
                return new ToolkitRepository(this);
            }
        }
        public AttachmentRepository Attachments
        {
            get
            {
                return new AttachmentRepository(this);
            }
        }
        public AspNetRoleRepository Roles
        {
            get
            {
                return new AspNetRoleRepository(this);
            }
        }
        public AspNetUserLoginRepository AspNetUserLogin
        {
            get
            {
                return new AspNetUserLoginRepository(this);
            }
        }
        public AspNetUserRepository AspNetUsers
        {
            get
            {
                return new AspNetUserRepository(this);
            }
        }
        public ComplianceResultRepository ComplianceResult
        {
            get
            {
                return new ComplianceResultRepository(this);
            }
        }
        public LogRepository Logs
        {
            get
            {
                return new LogRepository(this);
            }
        }
        public LookupCategoryRepository LookupCategory
        {
            get
            {
                return new LookupCategoryRepository(this);
            }
        }
        public LookupRepository Lookups
        {
            get
            {
                return new LookupRepository(this);
            }
        }
        public MandatoryValuesAndWeightRepository MandatoryValuesAndWeights
        {
            get
            {
                return new MandatoryValuesAndWeightRepository(this);
            }
        }
        public NotificaitonsHistoryRepository NotificaitonsHistory
        {
            get
            {
                return new NotificaitonsHistoryRepository(this);
            }
        }
        public NotificationRepository Notifications
        {
            get
            {
                return new NotificationRepository(this);
            }
        }
        public QuestionsAssessmentDetailRepository QuestionsAssessmentDetails
        {
            get
            {
                return new QuestionsAssessmentDetailRepository(this);
            }
        }
        public QuestionsDetailRepository Questions
        {
            get
            {
                return new QuestionsDetailRepository(this);
            }
        }
        public RecomendedValuesAndWeightRepository RecomendedValuesAndWeights
        {
            get
            {
                return new RecomendedValuesAndWeightRepository(this);
            }
        }
        public ServiceRequestRepository ServiceRequests
        {
            get
            {
                return new ServiceRequestRepository(this);
            }
        }

        public StandardRepository Standards
        {
            get
            {
                return new StandardRepository(this);
            }
        }
        public UserRepository Users
        {
            get
            {
                return new UserRepository(this);
            }
        }

       public TemplateRepository Templates
        {
            get
            {
                return new TemplateRepository(this);
            }
        }



        public BaseQuestionsRepository BaseQuestions
        {
            get
            {
                return new BaseQuestionsRepository(this);
            }
        }

        public void Save()
        {
            try
            {
                _context.ChangeTracker.DetectChanges();
                var modifiedEntities = _context.ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
                var now = DateTime.UtcNow;

                foreach (var change in modifiedEntities)
                {
                    var entityName = change.Entity.GetType().Name;
                    var primaryKey = GetPrimaryKeyValue(change);

                    foreach (var prop in change.OriginalValues.PropertyNames)
                    {
                        var originalValue = change.OriginalValues[prop];
                        var currentValue = change.CurrentValues[prop];
                        if (originalValue != null && originalValue.ToString() != currentValue.ToString())
                        {
                            Tracer.Information($"Database change - entity: {entityName}, Key: {primaryKey}, originalValue: {originalValue}, CurrentValue : {currentValue}");
                        }
                    }
                }

                _context.SaveChanges();
            }
            catch (DbEntityValidationException exp)
            {
                ThrowEnhancedValidationException(exp);
            }
        }

        public void SaveChanges()
        {
            if (_dbContextTransaction == null)
            {
                _dbContextTransaction = DbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            }
            try
            {
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO:Implement Logging 
                Rollback();
            }
        }


        public void Commit()
        {
            if (_dbContextTransaction != null)
            {
                DbContext.Database.CurrentTransaction.Commit();
                _dbContextTransaction = null;
            }
        }

        public void Rollback()
        {
            if (_dbContextTransaction != null)
            {
                DbContext.Database.CurrentTransaction.Rollback();
                _dbContextTransaction = null;
            }
        }


        ~UnitOfWork()
        {
            Rollback();
        }



        private void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }

        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this._context).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
