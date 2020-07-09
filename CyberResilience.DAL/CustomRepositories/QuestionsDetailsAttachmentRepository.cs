using CyberResilience.Common.DTOs.Attachment;
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
   public class QuestionsDetailsAttachmentRepository : Repository<QuestionsDetailsAttachment>
    {
        public QuestionsDetailsAttachmentRepository(UnitOfWork uow) : base(uow) { }
        public bool AddAttachment(QuestionAttachmentsDTO dto)
        {
            var savedAttachment = new QuestionsDetailsAttachment()
            {
                caption = dto.Caption,
                contentType = dto.ContentType,
                data = dto.Data,
                fileName = dto.FileName,
                QuestionDetailsID = dto.QuestionId
            };
            Create(savedAttachment);
            _uow.Save();
            bool isSaved = false;
            if (savedAttachment.AttachmentID > 0)
            {
                isSaved = true;
            }
            else
            {
                isSaved = false;
            }
            return isSaved;
        }
        public List<QuestionAttachmentsDTO> GetAttachments(int QuestionId)
        {
            var attachments = (from att in _db.QuestionsDetailsAttachments
                               where att.QuestionDetailsID == QuestionId
                               select new QuestionAttachmentsDTO()
                               {
                                   AttachmentID = att.AttachmentID,
                                   AttachmentId = att.AttachmentID,
                                   Caption = att.caption,
                                   ContentType = att.contentType,
                                   Data = att.data,
                                   FileName = att.fileName,
                                   FileNameWithExtension = att.fileName,
                                   Id = att.AttachmentID,
                                   QuestionId = att.QuestionDetailsID,
                               }).ToList();
            return attachments;
        }
        public QuestionAttachmentsDTO GetAttachmentByID(int AttachmentID)
        {
            QuestionAttachmentsDTO dto = new QuestionAttachmentsDTO();
            var attachment = GetQuerable(x => x.AttachmentID == AttachmentID).FirstOrDefault();
            dto.Id = attachment.AttachmentID;
            dto.QuestionId = attachment.QuestionDetailsID;
            dto.Data = attachment.data;
            dto.FileName = attachment.fileName;
            dto.ContentType = attachment.contentType;
            dto.AttachmentId = attachment.AttachmentID;
            dto.AttachmentID = attachment.AttachmentID;
            dto.Caption = attachment.caption;
            return dto;
        }
        public bool DeleteTemplateAttachments(int QuestionId)
        {
            var repo = _uow.QuestionAttachments;
            var attachments = GetQuerable(x => x.QuestionDetailsID == QuestionId);
            foreach (var i in attachments)
            {
                repo.Delete(i);
            }
            _uow.Save();
            return true;
        }
        public bool DeleteAttachment(int AttachmentID)
        {
            var repo = _uow.QuestionAttachments;
            var Attachments = GetQuerable(x => x.AttachmentID == AttachmentID);
            foreach (var i in Attachments)
            {
                repo.Delete(i);
            }
            _uow.Save();
            return true;
        }
        public bool DeleteQuestionAttachments(int QuestionId)
        {
            try
            {
                var attachments = GetQuerable(x => x.QuestionDetailsID == QuestionId).ToList();
                if (attachments != null && attachments.Count() > 0)
                {
                    var repo = _uow.QuestionAttachments;
                    foreach (var i in attachments)
                    {
                        repo.Delete(i);
                        _uow.Save();
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
                ex.Data.Add("DeleteAllBaseQuestionsDetailSubElements", "An error occurred while trying to DeleteAllBaseQuestionsDetailSubElements Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
    }
}
