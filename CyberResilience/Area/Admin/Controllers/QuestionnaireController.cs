using CyberResilience.Area.Admin.Models;
using CyberResilience.Base;
using CyberResilience.BLL.AdminBLL;
using CyberResilience.BLL.LookupsBusinessLogic;
using CyberResilience.Common.DTOs.Admin;
using CyberResilience.Common.DTOs.Admin.QuestionnairesDTO;
using CyberResilience.Mapper.WebMapper;
using System;
using System.Collections.Generic;
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
        private TemplatesMapper mapper;
        public QuestionnaireController()
        {
            _LookupCategoryBusinessLogic = new LookupCategoryBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
            _TemplateBusinessLogic = new TemplateBusinessLogic();
            _BaseQuestionsBusinessLogic = new BaseQuestionsBusinessLogic();
            mapper = new TemplatesMapper();
        }

        #region Templates
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
        #endregion
        #region Sub Elements
        [HttpGet]
        public ActionResult AddBaseQuestion(int? TemplateId)
        {
            BaseQuestionsViewModel model = new BaseQuestionsViewModel();
            model.baseTemplates = mapper.ConvertTemplatesToWeb(_TemplateBusinessLogic.GetTemplatesDropDownData());

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
                dto.clauseNameAr = model.BaseQuestionNameAr;
                dto.clauseNameEn = model.BaseQuestionNameEn;
                dto.baseTemplateId = model.baseTemplateId;
                dto.CreatedBy = "Admin";
                dto.CreatedDate = DateTime.Now;
                bool addtemplate = _BaseQuestionsBusinessLogic.AddBaseQuestions(dto);
                if (addtemplate == true)
                {
                    model.BaseQuestions = mapper.ConvertBaseQuestionsToWeb(_BaseQuestionsBusinessLogic.GetAllBaseQuestions(model.baseTemplateId));

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
        public ActionResult EditBaseQuestion(int BaseQuestionId)
        {
            var BaseQuestions = mapper.ConvertBaseQuestionsToWeb(_BaseQuestionsBusinessLogic.GetBaseQuestion(BaseQuestionId));
            BaseQuestions.baseTemplates = mapper.ConvertTemplatesToWeb(_TemplateBusinessLogic.GetTemplatesDropDownData());
            return View(BaseQuestions);
        }
        [HttpPost]
        public ActionResult EditBaseQuestion(BaseQuestionsViewModel model)
        {
            model.baseTemplates = mapper.ConvertTemplatesToWeb(_TemplateBusinessLogic.GetTemplatesDropDownData());
            //model.SubQuestions = mapper.ConvertQuestionsToWeb(_TemplateBusinessLogic.GetElementQuestions(model.Id));

            if (ModelState.IsValid)
            {
                BaseQuestionsDetailsDTO dto = new BaseQuestionsDetailsDTO();
                dto.clauseNameAr = model.BaseQuestionNameAr;
                dto.clauseNameEn = model.BaseQuestionNameEn;
                dto.baseTemplateId = model.baseTemplateId;
                dto.CreatedBy = CurrentUserName;
                dto.CreatedDate = DateTime.Now;
                bool EditBaseQuetsion = _BaseQuestionsBusinessLogic.EditBaseQuestion(dto);
                if (EditBaseQuetsion == true)
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
        [HttpPost]
        public ActionResult AddQuestion(QuestionsViewModel model)
        {

            return View();
        }
        [HttpGet]
        public ActionResult QuestionDetails(int BaseQuestionId)
        {

            return View();
        }
        [HttpGet]
        public ActionResult EditQuestion(int QuestionId)
        {

            return View();
        }
        [HttpGet]
        public ActionResult DeleteQuestion(int QuestionId)
        {
            return View();
        }
        [HttpGet]
        public ActionResult BaseQuestionsSubs(int BaseQuestionId)
        {

            return View();
        }
        #endregion












    }
}