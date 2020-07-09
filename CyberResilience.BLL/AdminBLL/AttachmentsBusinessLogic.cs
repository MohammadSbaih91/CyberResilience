using CyberResilience.Common.DTOs.Attachment;
using CyberResilience.Common.Utilities;
using CyberResilience.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.BLL.AdminBLL
{
    public class AttachmentsBusinessLogic
    {
        #region Template Attachments
        public bool AddAttachment(AttachmentDTO dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var isAdded = uow.Attachments.AddAttachment(dto);
                    if (isAdded == true)
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
                    ex.Data.Add("AddQuestion", "An error occurred while trying to create Question Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public List<AttachmentDTO> GetAttachments(int TemplateID)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    List<AttachmentDTO> dto = new List<AttachmentDTO>();
                    dto = uow.Attachments.GetAttachments(TemplateID);
                    if (dto != null && dto.Count > 0)
                    {
                        foreach (var item in dto)
                        {
                            string img = Convert.ToBase64String(item.Data);
                            item.ImagePath = string.Format("data:image/gif;base64,{0}", img);
                        }
                        return dto;
                    }
                    else
                    {
                        return dto;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetAttachments", "An error occurred while trying to Get Attachments Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public AttachmentDTO GetAttachmentByID(int AttachmentID)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    AttachmentDTO dto = new AttachmentDTO();
                    dto = uow.Attachments.GetAttachmentByID(AttachmentID);
                    if (dto != null)
                    {
                        return dto;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetAttachmentByID", "An error occurred while trying to Get Attachment By ID Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public bool DeleteTemplateAttachments(int TemplateID)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var isAdded = uow.Attachments.DeleteTemplateAttachments(TemplateID);
                    if (isAdded == true)
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
                    ex.Data.Add("DeleteTemplateAttachments", "An error occurred while trying to Delete Template Attachments Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public bool DeleteAttachment(int AttachmentID)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var isAdded = uow.Attachments.DeleteAttachment(AttachmentID);
                    if (isAdded == true)
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
                    ex.Data.Add("DeleteAttachment", "An error occurred while trying to Delete Attachment Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }

        #endregion

        #region QuestionDetails Attachments
        public bool AddQuestionAttachment(QuestionAttachmentsDTO dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var isAdded = uow.QuestionAttachments.AddAttachment(dto);
                    if (isAdded == true)
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
                    ex.Data.Add("AddQuestionAttachment", "An error occurred while trying to create Question Attachment Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public List<QuestionAttachmentsDTO> GetQuestionAttachments(int TemplateID)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    List<QuestionAttachmentsDTO> dto = new List<QuestionAttachmentsDTO>();
                    dto = uow.QuestionAttachments.GetAttachments(TemplateID);
                    if (dto != null && dto.Count > 0)
                    {
                        foreach (var item in dto)
                        {
                            string img = Convert.ToBase64String(item.Data);
                            item.ImagePath = string.Format("data:image/gif;base64,{0}", img);
                        }
                        return dto;
                    }
                    else
                    {
                        return dto;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetQuestionAttachments", "An error occurred while trying to Get Question Attachments Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public QuestionAttachmentsDTO GetQuestionAttachmentByID(int AttachmentID)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    QuestionAttachmentsDTO dto = new QuestionAttachmentsDTO();
                    dto = uow.QuestionAttachments.GetAttachmentByID(AttachmentID);
                    if (dto != null)
                    {
                        return dto;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetAttachmentByID", "An error occurred while trying to Get Question Attachment By ID Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public bool DeleteQuestionAttachments(int TemplateID)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var isAdded = uow.QuestionAttachments.DeleteTemplateAttachments(TemplateID);
                    if (isAdded == true)
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
                    ex.Data.Add("DeleteTemplateAttachments", "An error occurred while trying to Delete Question Attachments Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public bool DeleteQuestionAttachment(int AttachmentID)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var isAdded = uow.QuestionAttachments.DeleteAttachment(AttachmentID);
                    if (isAdded == true)
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
                    ex.Data.Add("DeleteQuestionAttachment", "An error occurred while trying to Delete Question Attachment Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }



        #endregion

    }
}
