using CyberResilience.Area.Admin.Models;
using CyberResilience.Base;
using CyberResilience.BLL.AdminBLL;
using CyberResilience.BLL.LookupsBusinessLogic;
using CyberResilience.Common.DTOs.Admin;
using CyberResilience.Common.DTOs.Admin.QuestionnairesDTO;
using CyberResilience.Common.DTOs.Attachment;
using CyberResilience.Mapper.WebMapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberResilience.Area.Admin.Controllers
{
    public class QuestionnaireController : BaseController
    {
        private LookupCategoryBusinessLogic _LookupCategoryBusinessLogic;
        private LookupsBusinessLogic _LookupsBusinessLogic;
        private TemplateBusinessLogic _TemplateBusinessLogic;
        private BaseQuestionsBusinessLogic _BaseQuestionsBusinessLogic;
        private QuestionsBusinessLogic _QuestionsBusinessLogic;
        private AttachmentsBusinessLogic _AttachmentsBusinessLogic;
        private TemplatesMapper mapper;
        public QuestionnaireController()
        {
            _LookupCategoryBusinessLogic = new LookupCategoryBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
            _TemplateBusinessLogic = new TemplateBusinessLogic();
            _BaseQuestionsBusinessLogic = new BaseQuestionsBusinessLogic();
            _QuestionsBusinessLogic = new QuestionsBusinessLogic();
            _AttachmentsBusinessLogic = new AttachmentsBusinessLogic();
            mapper = new TemplatesMapper();
        }

        #region Templates
        [HttpGet]
        public ActionResult Content(int TemplateId)
        {

            BaseTemplateViewModel model = new BaseTemplateViewModel();
            model.TemplateTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", base.CurrentCulture);
            model.TemplateSubTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", base.CurrentCulture);
            var content = _TemplateBusinessLogic.GetTemplate(TemplateId);
            model.Id = content.Id;
            model.IsEmptyAttachments = content.WithNoAttachments;
            model.IsEmptyQuestions = content.WithNoQuestions;
            model.TemplateNameAr = content.TemplateNameAr;
            model.TemplateNameEn = content.TemplateNameEn;
            model.TemplateSubType = content.TemplateSubType;
            model.TemplateType = content.TemplateType;
            model.BaseQuestions = mapper.ConvertBaseQuestionsToWeb(content.baseQuestions);
            model.Attachments = mapper.ConvertAttachmentsToWeb(content.attachments);

            return View(model);
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Templates()
        {
            var templates = mapper.ConvertTemplatesToWeb(_TemplateBusinessLogic.GetAllTemplates());
            return View(templates);
        }
        [HttpGet]
        public ActionResult CreateTemplate()
        {
            BaseTemplateViewModel model = new BaseTemplateViewModel();
            model.TemplateTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", base.CurrentCulture);
            model.TemplateSubTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", base.CurrentCulture);
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateTemplate(BaseTemplateViewModel model)
        {
            model.TemplateTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", base.CurrentCulture);
            model.TemplateSubTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", base.CurrentCulture);

            if (ModelState.IsValid)
            {
                TemplateDTO dto = new TemplateDTO();
                dto.TemplateNameAr = model.TemplateNameAr;
                dto.TemplateNameEn = model.TemplateNameEn;
                dto.TemplateSubType = model.TemplateSubType;
                dto.TemplateType = model.TemplateType;


                bool addtemplate = _TemplateBusinessLogic.AddTemplate(dto);
                if (addtemplate == true)
                {
                    TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.CreateQuestionnaireSucces;
                    return View(model);
                }
                else
                {
                    TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.CreateQuestionnaireFailed;
                    return View(model);
                }
            }
            else
            {
                TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.CreateQuestionnaireFailed;
                return View(model);
            }

        }
        [HttpGet]
        public ActionResult EditTemplate(int TemplateId)
        {
            var templates = mapper.ConvertTemplateToWeb(_TemplateBusinessLogic.GetTemplate(TemplateId));
            templates.TemplateTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", base.CurrentCulture);
            templates.TemplateSubTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", base.CurrentCulture);
            return View(templates);
        }
        [HttpPost]
        public ActionResult EditTemplate(BaseTemplateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var template = mapper.ConvertTemplateToBLL(model);
                var isEdited = _TemplateBusinessLogic.EditTemplate(template);
                model.TemplateTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", base.CurrentCulture);
                model.TemplateSubTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", base.CurrentCulture);
                if (isEdited == true)
                {

                    TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.UpdateQuestionnaireSucces;
                    return View(model);
                }
                else
                {
                    TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.UpdateQuestionnaireFailed;
                    return View(model);
                }
            }
            else
            {
                TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.UpdateQuestionnaireFailed;
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult TemplateDetails(int TemplateId)
        {
            var template = mapper.ConvertTemplateToWeb(_TemplateBusinessLogic.GetTemplate(TemplateId));
            template.TemplateTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", base.CurrentCulture);
            template.TemplateSubTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", base.CurrentCulture);
            return View(template);
        }
        [HttpGet]
        public ActionResult DeleteTemplate(int TemplateId)
        {
            if (TemplateId >= 1)
            {
                var isDeleted = _TemplateBusinessLogic.DeleteTemplate(TemplateId);
                if (isDeleted == true)
                {
                    TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.DeleteQuestionnaireSucces;
                    return RedirectToAction("Templates");
                }
                else
                {
                    TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.DeleteQuestionnaireFailed;
                    return RedirectToAction("Templates");
                }
            }
            else
            {
                TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.DeleteQuestionnaireFailed;
                return RedirectToAction("Templates");
            }
        }
        [HttpGet]
        public ActionResult AddAttachmentPartial(int TemplateId)
        {
            AttachmentViewModel model = new AttachmentViewModel();
            model.TemplateId = TemplateId;

            return PartialView("~/Views/Shared/Partials/_Attachment.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddTemplateAttachments(int TemplateId)
        {
            AttachmentViewModel model = new AttachmentViewModel();
            model.TemplateId = TemplateId;
            if (TemplateId > 1)
            {
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].FileName != "")
                    {
                        string fileName = Request.Files[upload].FileName;
                        string contentType = Request.Files[upload].ContentType;
                        long fileLength = Request.Files[upload].InputStream.Length;
                        byte[] fileContent = new byte[fileLength];
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            Request.Files[upload].InputStream.CopyTo(memoryStream);
                            fileContent = memoryStream.ToArray();
                        }
                        //HttpPostedFileBase photo = Request.Files["ImageFile"];
                        AttachmentDTO dto = new AttachmentDTO();
                        dto.FileName = fileName;
                        dto.TemplateId = TemplateId;
                        dto.Data = fileContent;
                        dto.ContentType = contentType;
                        dto.FileNameWithExtension = fileName;
                        bool saved = _AttachmentsBusinessLogic.AddAttachment(dto);
                    }
                    TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.Success;
                }
                return RedirectToAction("Templates");
            }
            else
            {
                TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.Error;
                return RedirectToAction("Templates");
            }
        }
        #endregion
        #region Sub Elements
        [HttpGet]
        public ActionResult AddBaseQuestion(int? TemplateId)
        {
            BaseQuestionsViewModel model = new BaseQuestionsViewModel();
            model.baseTemplates = mapper.ConvertTemplatesToWeb(_TemplateBusinessLogic.GetTemplatesDropDownData());
            //if (TemplateId != null && TemplateId.HasValue == true)
            //{
            //    model.BaseQuestions = mapper.ConvertBaseQuestionsToWeb(_BaseQuestionsBusinessLogic.GetAllBaseQuestions(TemplateId.Value));
            //}
            return View(model);
        }
        [HttpPost]
        public ActionResult AddBaseQuestion(BaseQuestionsViewModel model)
        {
            model.baseTemplates = mapper.ConvertTemplatesToWeb(_TemplateBusinessLogic.GetTemplatesDropDownData());
            //model.SubQuestions = mapper.ConvertQuestionsToWeb(_TemplateBusinessLogic.GetElementQuestions(model.Id));

            if (ModelState.IsValid)
            {
                BaseQuestionsDetailsDTO dto = new BaseQuestionsDetailsDTO();
                dto.BaseQuestionNameAr = model.BaseQuestionNameAr;
                dto.BaseQuestionNameEn = model.BaseQuestionNameEn;
                dto.baseTemplateId = model.baseTemplateId;
                dto.CreatedBy = "Admin";
                dto.CreatedDate = DateTime.Now;
                bool addtemplate = _BaseQuestionsBusinessLogic.AddBaseQuestions(dto);
                if (addtemplate == true)
                {
                    
                    //model.BaseQuestions = mapper.ConvertBaseQuestionsToWeb(_BaseQuestionsBusinessLogic.GetAllBaseQuestions(model.baseTemplateId));
                    TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.CreateQuestionnaireSucces;
                    return RedirectToAction("Content" , new { TemplateId = model.baseTemplateId });
                    //return View(model);
                }
                else
                {
                    TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.CreateQuestionnaireFailed;
                    return View(model);
                }
            }
            else
            {
                TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.CreateQuestionnaireFailed;
                return View(model);
            }

        }
        [HttpGet]
        public ActionResult EditBaseQuestion(int BaseQuestionId)
        {
            BaseQuestionsViewModel model = new BaseQuestionsViewModel();
            model = mapper.ConvertBaseQuestionsToWeb(_BaseQuestionsBusinessLogic.GetBaseQuestion(BaseQuestionId));
            model.baseTemplates = mapper.ConvertTemplatesToWeb(_TemplateBusinessLogic.GetTemplatesDropDownData());
            return View(model);
        }
        [HttpPost]
        public ActionResult EditBaseQuestion(BaseQuestionsViewModel model)
        {
            model.baseTemplates = mapper.ConvertTemplatesToWeb(_TemplateBusinessLogic.GetTemplatesDropDownData());
            if (ModelState.IsValid)
            {
                BaseQuestionsDetailsDTO dto = new BaseQuestionsDetailsDTO();
                dto = mapper.ConvertBaseQuestionsToBLL(model);
                bool EditBaseQuetsion = _BaseQuestionsBusinessLogic.EditBaseQuestion(dto);
                if (EditBaseQuetsion == true)
                {
                    TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.CreateQuestionnaireSucces;
                    return RedirectToAction("EditBaseQuestion",new { BaseQuestionId = model.Id });
                }
                else
                {
                    TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.CreateQuestionnaireFailed;
                    return RedirectToAction("EditBaseQuestion", new { BaseQuestionId = model.Id });
                }
            }
            else
            {
                TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.CreateQuestionnaireFailed;
                return RedirectToAction("EditBaseQuestion", new { BaseQuestionId = model.Id });
            }

        }
        [HttpGet]
        public ActionResult BaseQuestionDetails(int BaseQuestionId)
        {
            var baseQuestion = mapper.ConvertBaseQuestionsToWeb(_BaseQuestionsBusinessLogic.GetBaseQuestion(BaseQuestionId));
            baseQuestion.baseTemplates = mapper.ConvertTemplatesToWeb(_TemplateBusinessLogic.GetTemplatesDropDownData());

            return View(baseQuestion);
        }
        [HttpGet]
        public ActionResult DeleteBaseQuestion(int BaseQuestionId)
        {
            if (BaseQuestionId >= 1)
            {
                var isDeleted = _BaseQuestionsBusinessLogic.DeleteBaseQuestion(BaseQuestionId);
                if (isDeleted > 0)
                {
                    TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.DeleteQuestionnaireSucces;
                    return RedirectToAction("Content", new { TemplateId = isDeleted });
                }
                else
                {
                    TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.DeleteQuestionnaireFailed;
                    return RedirectToAction("Content", new { TemplateId = isDeleted });
                }
            }
            else
            {
                TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.DeleteQuestionnaireFailed;
                return RedirectToAction("Templates");
            }
        }
        [HttpGet]
        public ActionResult AddBaseQuestionPartial(int? TemplateId)
        {
            List<BaseQuestionsViewModel> model = new List<BaseQuestionsViewModel>();
            if (TemplateId.HasValue)
            {
                model = mapper.ConvertBaseQuestionsToWeb(_BaseQuestionsBusinessLogic.GetAllBaseQuestions(TemplateId.Value));
            }
            return PartialView("~/Views/Shared/Partials/_BaseQuestions.cshtml", model);
        }
        #endregion
        #region Questions
        [HttpGet]
        public ActionResult AddQuestion(int BaseQuestionId)
        {
            QuestionsViewModel model = new QuestionsViewModel();
            model = mapper.ConvertAddQuestionsToWeb(_BaseQuestionsBusinessLogic.GetBaseQuestion(BaseQuestionId));
            return View(model);
        }
        [HttpGet]
        public ActionResult AddQuestionPartial(int BaseQuestionId)
        {
            QuestionsViewModel model = new QuestionsViewModel();
            model = mapper.ConvertAddQuestionsToWeb(_BaseQuestionsBusinessLogic.GetBaseQuestion(BaseQuestionId));
            return PartialView("~/Views/Shared/Partials/_Questions.cshtml", model);
        }

        [HttpGet]
        public ActionResult AddQuestionAttachmentPartial(int QuestionId )
        {
            AttachmentViewModel model = new AttachmentViewModel();
            //model.TemplateId = _QuestionsBusinessLogic.GetBaseQuestionIdPerQuestionId(QuestionId);
            model.QuestionId = QuestionId;
            return PartialView("~/Views/Shared/Partials/_QuestionAttachment.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddQuestionAttachment(int QuestionId)
        {
            AttachmentViewModel model = new AttachmentViewModel();
            model.QuestionId = QuestionId;
            if (QuestionId > 1)
            {
                foreach (string upload in Request.Files)
                {
                    if (Request.Files[upload].FileName != "")
                    {
                        string fileName = Request.Files[upload].FileName;
                        string contentType = Request.Files[upload].ContentType;
                        long fileLength = Request.Files[upload].InputStream.Length;
                        byte[] fileContent = new byte[fileLength];
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            Request.Files[upload].InputStream.CopyTo(memoryStream);
                            fileContent = memoryStream.ToArray();
                        }
                        //HttpPostedFileBase photo = Request.Files["ImageFile"];
                        QuestionAttachmentsDTO dto = new QuestionAttachmentsDTO();
                        dto.FileName = fileName;
                        dto.QuestionId = QuestionId;
                        dto.Data = fileContent;
                        dto.ContentType = contentType;
                        dto.FileNameWithExtension = fileName;
                        bool saved = _AttachmentsBusinessLogic.AddQuestionAttachment(dto);
                    }
                    TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.Success;
                }
                return RedirectToAction("Templates");
            }
            else
            {
                TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.Error;
                return RedirectToAction("Templates");
            }
        }
        [HttpPost]
        public ActionResult AddQuestion(QuestionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                QuestionsDetailsDTO dto = new QuestionsDetailsDTO();
                dto = mapper.ConvertQuestionsToBLL(model);
                int TempId = _QuestionsBusinessLogic.AddQuestions(dto);
                if (TempId > 0)
                {
                    TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.Success;
                    return RedirectToAction("AddBaseQuestion", new { TemplateId = TempId });
                }
                else
                {
                    TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.Error;
                    return RedirectToAction("AddBaseQuestion");
                }
            }
            return RedirectToAction("AddBaseQuestion");
        }
        [HttpGet]
        public ActionResult QuestionDetails(int BaseQuestionId)
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditQuestion(int QuestionId)
        {
            QuestionsViewModel model = new QuestionsViewModel();
            model = mapper.ConvertQuestionToWeb(_QuestionsBusinessLogic.GetQuestion(QuestionId));
            return View(model);
        }
        [HttpPost]
        public ActionResult EditQuestion(QuestionsViewModel model)
        {

            if (ModelState.IsValid)
            {
                QuestionsDetailsDTO dto = new QuestionsDetailsDTO();
                dto = mapper.ConvertQuestionsToBLL(model);
                bool isEdited = _QuestionsBusinessLogic.EditQuestion(dto);
                if (isEdited == true)
                {
                    TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.Success;
                    return RedirectToAction("AddBaseQuestion");
                }
                else
                {
                    TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.Error;
                    return RedirectToAction("AddBaseQuestion");
                }
            }
            return RedirectToAction("AddBaseQuestion");
        }
        [HttpGet]
        public ActionResult EditQuestionPartial(int QuestionId)
        {
            QuestionsViewModel model = new QuestionsViewModel();
            model = mapper.ConvertQuestionToWeb(_QuestionsBusinessLogic.GetQuestion(QuestionId));
            return PartialView("~/Views/Shared/Partials/_EditQuestions.cshtml", model);
        }
        [HttpGet]
        public ActionResult DeleteQuestion(int QuestionId)
        {
            bool isDeleted = _QuestionsBusinessLogic.DeleteQuestion(QuestionId);
            if (isDeleted == true)
            {
                TempData["Success"] = CyberResilience.Common.App_LocalResources.Resource.Success;
                return RedirectToAction("AddBaseQuestion");
            }
            else
            {
                TempData["Error"] = CyberResilience.Common.App_LocalResources.Resource.Error;
                return RedirectToAction("AddBaseQuestion");
            }
        }
        [HttpGet]
        public ActionResult BaseQuestionsSubs(int BaseQuestionId)
        {

            return View();
        }
        #endregion
        #region Attachment
        public ActionResult AttachmentsList(int TemplateId)
        {

            return View();
        }
        public ActionResult DownloadAttachment(int Id)
        {
            AttachmentViewModel attachment = new AttachmentViewModel();

            attachment = mapper.ConvertAttachmentToWeb(_AttachmentsBusinessLogic.GetAttachmentByID(Id));
            if (attachment != null && (attachment.Data != null && attachment.Data.Length > 0))
            {
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/plain";
                response.AddHeader("Content-Disposition", "inline; filename=" + attachment.FileName + ";");
                new System.IO.MemoryStream(attachment.Data).CopyTo(response.OutputStream);
                response.Flush();
                response.End();
            }
            return View();
        }
        public ActionResult DeleteAttachment(int Id , int TemplateId)
        {

            var isdeleted = _AttachmentsBusinessLogic.DeleteAttachment(Id);
            if (isdeleted == true)
            {
                TempData["Success"] = "تمت حذف المرفق بنجاح";
                return RedirectToAction("Content", new { TemplateId = TemplateId });

            }
            TempData["Success"] = "لم يتم حذف الرفق ";
            return RedirectToAction("Content", new { TemplateId = TemplateId });

        }

        public ActionResult DeleteQuestionAttachment(int Id, int TemplateId)
        {

            var isdeleted = _AttachmentsBusinessLogic.DeleteQuestionAttachment(Id);

            if (isdeleted == true)
            {
                TempData["Success"] = "تمت حذف المرفق بنجاح";
                return RedirectToAction("Content", new { TemplateId = TemplateId });

            }
            TempData["Success"] = "لم يتم حذف الرفق ";
            return RedirectToAction("Content", new { TemplateId = TemplateId });

        }
        #endregion

    }
}