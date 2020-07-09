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
    public class AttachmentRepository : Repository<Attachment>
    {
        public AttachmentRepository(UnitOfWork uow) : base(uow) { }
        public bool AddAttachment(AttachmentDTO dto)
        {
            var savedAttachment = new Attachment()
            {
               
                caption=dto.Caption,
                contentType=dto.ContentType,
                data=dto.Data,
                fileName=dto.FileName,
                TemplateID=dto.TemplateId
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
        public List<AttachmentDTO> GetAttachments(int TemplateID)
        {
            var attachments = (from att in _db.Attachments
                               where att.TemplateID == TemplateID
                               select new AttachmentDTO()
                               {
                                  AttachmentID=att.AttachmentID,
                                  AttachmentId=att.AttachmentID,
                                  Caption=att.caption,
                                  ContentType=att.contentType,
                                  Data=att.data,
                                  FileName=att.fileName,
                                  FileNameWithExtension=att.fileName,
                                  Id=att.AttachmentID,
                                  TemplateId=att.TemplateID,
                               }).ToList();
            return attachments;
        }
        public AttachmentDTO GetAttachmentByID(int AttachmentID)
        {
            AttachmentDTO dto = new AttachmentDTO();
            var attachment = GetQuerable(x => x.AttachmentID == AttachmentID).FirstOrDefault();
            dto.Id = attachment.AttachmentID;
            dto.TemplateId = attachment.TemplateID;
            dto.Data = attachment.data;
            dto.FileName = attachment.fileName;
            dto.ContentType = attachment.contentType;
            dto.AttachmentId = attachment.AttachmentID;
            dto.AttachmentID = attachment.AttachmentID;
            dto.Caption = attachment.caption;
            return dto;
        }
        public bool DeleteTemplateAttachments(int TemplateID)
        {
            try
            {
                var repo = _uow.Attachments;
                var attachments = GetQuerable(x => x.TemplateID == TemplateID);
                if (attachments != null)
                {
                    foreach (var i in attachments)
                    {
                        repo.Delete(i);
                    }
                    _uow.Save();
                    return true;
                }
                else
                {
                    return true;

                }
            }

            catch (Exception ex)
            {
                ex.Data.Add("DeleteTemplateAttachments ", "An error occurred while trying to Delete Template record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteAttachment(int AttachmentID)
        {
            var repo = _uow.Attachments;
            var Attachments = GetQuerable(x => x.AttachmentID == AttachmentID);
            foreach (var i in Attachments)
            {
                repo.Delete(i);
            }
            _uow.Save();
            return true;
        }
    }
}
