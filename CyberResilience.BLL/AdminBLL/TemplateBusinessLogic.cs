using CyberResilience.Common.DTOs.Admin;
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
    public class TemplateBusinessLogic
    {
        public bool AddTemplate(TemplateDTO dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var templateAdded = uow.Templates.AddTemplate(dto);
                    if (templateAdded != false)
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
                    ex.Data.Add("AddTemplate", "An error occurred while trying to create Template Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public List<TemplateDTO> GetAllTemplates()
        {
            using (var uow = new UnitOfWork())
            {

                try
                {
                    var templates = uow.Templates.GetAllTemplates();
                    if (templates != null)
                    {
                        foreach(var template in templates)
                        {
                            if (template.baseQuestions!= null && template.baseQuestions.Count <= 0)
                            {
                                template.WithNoQuestions = true;
                            }
                            else
                            {
                                template.WithNoQuestions = false;
                            }

                            if (template.attachments != null &&  template.attachments.Count <= 0)
                            {
                                template.WithNoAttachments = true;
                            }
                            else
                            {
                                template.WithNoAttachments = false;
                            }
                        }

                        return templates;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetAllTemplates", "An error occurred while trying to get all Templates Records - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public TemplateDTO GetTemplate(int TemplateId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var templates = uow.Templates.GetTemplate(TemplateId);
                    if (templates != null)
                    {
                        return templates;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetTemplate", "An error occurred while trying to get  Template Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
        public bool EditTemplate(TemplateDTO dto)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var templates = uow.Templates.EditTemplate(dto);
                    if (templates != false)
                    {
                        return templates;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("EditTemplate", "An error occurred while trying to edit Template Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public bool DeleteTemplate(int TemplateId)
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var deletedSubElements = uow.BaseQuestions.DeleteAllTemplateSubElements(TemplateId);
                    if (deletedSubElements == true)
                    {
                        var templates = uow.Templates.DeleteTemplate(TemplateId);
                        if (templates != false)
                        {
                            return templates;
                        }
                        else
                        {
                            uow.Rollback();
                            return false;
                        }
                    }
                    else
                    {
                        uow.Rollback();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("DeleteTemplate", "An error occurred while trying to delete Template Record - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return false;
                }
            }
        }
        public List<TemplateDTO> GetTemplatesDropDownData()
        {
            using (var uow = new UnitOfWork())
            {
                try
                {
                    var templates = uow.Templates.GetTemplatesDropDownData();
                    if (templates != null)
                    {
                        //TemplatesMapper.
                        return templates;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetTemplatesDropDownData", "An error occurred while trying to get all Templates in drop down Records - BLL");
                    uow.Rollback();
                    Tracer.Error(ex);
                    return null;
                }
            }
        }
    


    }
}
