using CyberResilience.Base;
using CyberResilience.BLL.AdminBLL;
using CyberResilience.BLL.LookupsBusinessLogic;
using CyberResilience.BLL.ServiceRequestsBusinessLogic;
using CyberResilience.Common;
using CyberResilience.Common.DTOs.ServiceRequestsDTO;
using CyberResilience.Mapper.WebMapper;
using CyberResilience.Models.FreeServicesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CyberResilience.Common.Constants;
using static CyberResilience.Common.Enums;

namespace CyberResilience.Controllers.Services
{
    [Authorize(Roles = "RegisteredUser, Employee, Admin")]
    public class FreeServicesController : BaseController
    {
        private LookupCategoryBusinessLogic _LookupCategoryBusinessLogic;
        private LookupsBusinessLogic _LookupsBusinessLogic;
        private ServiceRequestBusinessLogic _ServiceRequestBusinessLogic;
        private TemplateBusinessLogic _TemplateBusinessLogic;
        private FreeServicesMapper mapper;
        public FreeServicesController()
        {
            _LookupCategoryBusinessLogic = new LookupCategoryBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
            _ServiceRequestBusinessLogic = new ServiceRequestBusinessLogic();
            _TemplateBusinessLogic = new TemplateBusinessLogic();
            mapper = new FreeServicesMapper();
        }
        // GET: FreeServices
        [Authorize(Roles = "RegisteredUser, Employee, Admin")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "RegisteredUser, Employee, Admin")]
        [HttpGet]
        public ActionResult QuickOnlineAssessment()
        {
            if (!String.IsNullOrEmpty(base.CurrentUserName))
            {
                QuickOnlineAssessmentViewModel model = new QuickOnlineAssessmentViewModel();
                model.TemplateTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", base.CurrentCulture);
                model.TemplateSubTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", base.CurrentCulture);
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [Authorize(Roles = "RegisteredUser, Employee, Admin")]
        [HttpPost]
        public ActionResult QuickOnlineAssessment(QuickOnlineAssessmentViewModel model)
        {

            ModelState.Clear();
            model.ServiceType = (int)Enums.TemplateTypes.Quastionnaire;
            model.CreatedBy = base.CurrentUserName;
            model.CreatedDate = DateTime.Now;
            model.ServicePaymentType = (int)PaymentType.FreeService;
            model.ServiceType = model.ServiceType;
            model.ServiceRequestStatus = (int)ServiceRequestStatus.New;
            model.UserName = base.CurrentUserName;
            model.ServiceName = model.ServiceName;
            ServiceRequestsDTO dto = mapper.ConvertQuickOnlineAssessmentToBLL(model);
            int IsAdded = _ServiceRequestBusinessLogic.CreateServiceRequest(dto);
            return RedirectToAction("QuickOnlineAssessmentResult", new { ServiceRequestId = IsAdded });
        }
        [Authorize(Roles = "RegisteredUser, Employee, Admin")]
        [HttpGet]
        public ActionResult QuickOnlineAssessmentResult(int ServiceRequestId)
        {
            QuickOnlineAssessmentResultViewModel model = new QuickOnlineAssessmentResultViewModel();
            var dto = _ServiceRequestBusinessLogic.GetQuickOnlineAssessmentResult(ServiceRequestId, base.CurrentUserName);
            model = mapper.ConvertQuickOnlineAssessmentResultToWeb(dto);
            return View(model);
        }
        [Authorize(Roles = "RegisteredUser, Employee, Admin")]
        [HttpGet]
        public ActionResult QuastionnaireBodyPartial(int? subType)
        {
            QuickOnlineAssessmentViewModel model = new QuickOnlineAssessmentViewModel();
            #region type checking
            if (subType.HasValue)
            {
                switch (subType)
                {
                    case (int)TemplateSubTypes.SAMA:
                        subType = (int)TemplateSubTypes.SAMA;
                        break;
                    case (int)TemplateSubTypes.ISO24:
                        subType = (int)TemplateSubTypes.ISO24;
                        break;
                    case (int)TemplateSubTypes.ECC:
                        subType = (int)TemplateSubTypes.ECC;
                        break;
                    default:
                        subType = (int)TemplateSubTypes.ISO27;
                        break;
                }
            }
            else
            {
                subType = (int)TemplateSubTypes.ISO27;
            }
            if (base.CurrentCulture == CyberResilience.Common.Enums.Culture.Arabic)
            {
                model.Template = model.TemplateNameAr;
                model.Type = _LookupsBusinessLogic.GetLookupByID((int)Enums.TemplateTypes.Quastionnaire).ValueAr;
                model.SubType = _LookupsBusinessLogic.GetLookupByID(subType.Value).ValueAr;
            }
            else
            {
                model.Template = model.TemplateNameEn;
                model.Type = _LookupsBusinessLogic.GetLookupByID((int)Enums.TemplateTypes.Quastionnaire).ValueEn;
                model.SubType = _LookupsBusinessLogic.GetLookupByID(model.TemplateSubType).ValueEn;
            }

            #endregion
            model = mapper.ConvertQuickOnlineAssessmentToWeb(_TemplateBusinessLogic.GetTemplateByType((int)Enums.TemplateTypes.Quastionnaire, subType.Value), base.CurrentCulture , model.SubType);
         
            model.ServiceType = (int)Enums.TemplateTypes.Quastionnaire;

            //Mix Two lookups To generate Service Name Lookups
            //model.ServiceName = _LookupsBusinessLogic.GetLookupByLookupCode(TemplatesType.Quastionnaire+model.SubType,base.CurrentCulture).Value;

            return PartialView("~/Views/Shared/Partials/FreeServices/_QuickOnlineAssessmentTable.cshtml", model);
        }
        [HttpPost]
        public ActionResult ArhciveAssessment(QuickOnlineAssessmentViewModel model)
        {
            
        
            model.CreatedBy = base.CurrentUserName;
            model.CreatedDate = DateTime.Now;
            model.ServicePaymentType = (int)PaymentType.FreeService;
            model.ServiceRequestStatus = (int)ServiceRequestStatus.Archived;
            model.UserName = base.CurrentUserName;
            model.ServiceType= (int)Enums.TemplateTypes.Quastionnaire;
            ServiceRequestsDTO dto = mapper.ConvertQuickOnlineAssessmentToBLL(model);
            int IsAdded = _ServiceRequestBusinessLogic.CreateServiceRequest(dto);
            TempData["Success"] = Common.App_LocalResources.Resource.Success;
            return RedirectToAction("Index", "Platform");
        }
        [HttpPost]
        public ActionResult DeleteAssessmentResult(QuickOnlineAssessmentResultViewModel model)
        {
          bool isDeleted = _ServiceRequestBusinessLogic.DeleteAssessmentResult(model.Id);
            return RedirectToAction("Index", "Platform");
        }
        [HttpPost]
        public ActionResult DraftAssessmentResult(QuickOnlineAssessmentResultViewModel model)
        {
            bool isArchive = _ServiceRequestBusinessLogic.DraftAssessmentResult(model.Id);
            return RedirectToAction("Index", "Platform");
        }
        [HttpPost]
        public ActionResult ConsultationServiceRequest(QuickOnlineAssessmentResultViewModel model)
        {
            bool isArchive = _ServiceRequestBusinessLogic.ConsultationServiceRequest(model.Id);
            return RedirectToAction("Index", "Platform");
        }
    }
}