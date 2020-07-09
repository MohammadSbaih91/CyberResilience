namespace CyberResilience.DAL.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BlockedIP> BlockedIPs { get; set; }
        public virtual DbSet<ComplianceResultMessage> ComplianceResultMessages { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LookupCategory> LookupCategories { get; set; }
        public virtual DbSet<LookupCategoryCulture> LookupCategoryCultures { get; set; }
        public virtual DbSet<LookupCulture> LookupCultures { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<LookupsMapping> LookupsMappings { get; set; }
        public virtual DbSet<NotificaitonsHistory> NotificaitonsHistories { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }
        public virtual DbSet<Standard> Standards { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ComplianceResult> ComplianceResults { get; set; }
        public virtual DbSet<QuestionsAssessmentDetail> QuestionsAssessmentDetails { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<BaseQuestionsDetail> BaseQuestionsDetails { get; set; }
        public virtual DbSet<MandatoryValuesAndWeight> MandatoryValuesAndWeights { get; set; }
        public virtual DbSet<QuestionsDetail> QuestionsDetails { get; set; }
        public virtual DbSet<QuestionsDetailsAttachment> QuestionsDetailsAttachments { get; set; }
        public virtual DbSet<RecomendedValuesAndWeight> RecomendedValuesAndWeights { get; set; }
        public virtual DbSet<Questionnaire> Questionnaires { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Questionnaires)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.ServiceRequests)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.AspNetUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BlockedIP>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<ComplianceResultMessage>()
                .Property(e => e.ImplementationPeriodTimeMessageEn)
                .IsUnicode(false);

            modelBuilder.Entity<Culture>()
                .Property(e => e.CultureName)
                .IsUnicode(false);

            modelBuilder.Entity<Culture>()
                .HasMany(e => e.LookupCultures)
                .WithRequired(e => e.Culture)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LookupCategory>()
                .Property(e => e.FixedCode)
                .IsUnicode(false);

            modelBuilder.Entity<LookupCategory>()
                .HasMany(e => e.LookupCategories1)
                .WithOptional(e => e.LookupCategory1)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<LookupCategory>()
                .HasMany(e => e.Lookups)
                .WithRequired(e => e.LookupCategory)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Lookup>()
                .Property(e => e.LookupCode)
                .IsUnicode(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Lookups1)
                .WithOptional(e => e.Lookup1)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.NotificaitonsHistories)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.StatusCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Notifications)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.NotificationTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Notifications1)
                .WithRequired(e => e.Lookup1)
                .HasForeignKey(e => e.NotificationEventID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Questionnaires)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.QuestionnaireTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.ServiceRequests)
                .WithRequired(e => e.Lookup)
                .HasForeignKey(e => e.ServiceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.ServiceRequests1)
                .WithRequired(e => e.Lookup1)
                .HasForeignKey(e => e.ServicePaymentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.ServiceRequests2)
                .WithRequired(e => e.Lookup2)
                .HasForeignKey(e => e.ServiceRequestStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Standards)
                .WithOptional(e => e.Lookup)
                .HasForeignKey(e => e.StandardTypeId);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Lookup)
                .HasForeignKey(e => e.AccountTypeId);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Users1)
                .WithOptional(e => e.Lookup1)
                .HasForeignKey(e => e.ChannelId);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Users2)
                .WithOptional(e => e.Lookup2)
                .HasForeignKey(e => e.GenderId);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Users3)
                .WithRequired(e => e.Lookup3)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lookup>()
                .HasMany(e => e.Users4)
                .WithOptional(e => e.Lookup4)
                .HasForeignKey(e => e.NationalityId);

            modelBuilder.Entity<NotificaitonsHistory>()
                .Property(e => e.MobileNumber)
                .IsUnicode(false);

            modelBuilder.Entity<NotificaitonsHistory>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NotificaitonsHistory>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.NotificationTextEn)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.NotificationCode)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .HasMany(e => e.NotificaitonsHistories)
                .WithRequired(e => e.Notification)
                .HasForeignKey(e => e.NotificationTempleteID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceRequest>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceRequest>()
                .Property(e => e.LastUpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<ServiceRequest>()
                .HasOptional(e => e.ComplianceResult)
                .WithRequired(e => e.ServiceRequest);

            modelBuilder.Entity<ServiceRequest>()
                .HasOptional(e => e.Questionnaire)
                .WithRequired(e => e.ServiceRequest);

            modelBuilder.Entity<Standard>()
                .Property(e => e.StandardNameEn)
                .IsUnicode(false);

            modelBuilder.Entity<Standard>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Standard>()
                .Property(e => e.LastUpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Standard>()
                .HasMany(e => e.Questionnaires)
                .WithRequired(e => e.Standard)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Template>()
                .HasMany(e => e.Attachments)
                .WithRequired(e => e.Template)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstNameEn)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastNameEn)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<ComplianceResult>()
                .Property(e => e.QuestionnaireAccurateComplianceResult)
                .HasPrecision(18, 4);

            modelBuilder.Entity<ComplianceResult>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ComplianceResult>()
                .Property(e => e.LastUpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<ComplianceResult>()
                .HasMany(e => e.QuestionsAssessmentDetails)
                .WithRequired(e => e.ComplianceResult)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ComplianceResult>()
                .HasMany(e => e.Questionnaires)
                .WithRequired(e => e.ComplianceResult)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionsAssessmentDetail>()
                .Property(e => e.QuestionAssessmentValue)
                .HasPrecision(4, 4);

            modelBuilder.Entity<QuestionsAssessmentDetail>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionsAssessmentDetail>()
                .Property(e => e.LastUpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionsAssessmentDetail>()
                .HasMany(e => e.Questionnaires)
                .WithRequired(e => e.QuestionsAssessmentDetail)
                .HasForeignKey(e => e.AsessmentDetailsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attachment>()
                .Property(e => e.attachmentType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BaseQuestionsDetail>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BaseQuestionsDetail>()
                .Property(e => e.LastUpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<BaseQuestionsDetail>()
                .HasMany(e => e.QuestionsDetails)
                .WithOptional(e => e.BaseQuestionsDetail)
                .HasForeignKey(e => e.BaseQuestionDetailsId);

            modelBuilder.Entity<MandatoryValuesAndWeight>()
                .Property(e => e.MandatoryRequirementWeight)
                .HasPrecision(4, 4);

            modelBuilder.Entity<MandatoryValuesAndWeight>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<MandatoryValuesAndWeight>()
                .Property(e => e.LastUpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionsDetail>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionsDetail>()
                .Property(e => e.LastUpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionsDetail>()
                .HasMany(e => e.QuestionsDetailsAttachments)
                .WithRequired(e => e.QuestionsDetail)
                .HasForeignKey(e => e.QuestionDetailsID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionsDetailsAttachment>()
                .Property(e => e.attachmentType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RecomendedValuesAndWeight>()
                .Property(e => e.RecomendedRequirementWeight)
                .HasPrecision(4, 4);

            modelBuilder.Entity<RecomendedValuesAndWeight>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<RecomendedValuesAndWeight>()
                .Property(e => e.LastUpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Questionnaire>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Questionnaire>()
                .Property(e => e.LastUpdateBy)
                .IsUnicode(false);
        }
    }
}
