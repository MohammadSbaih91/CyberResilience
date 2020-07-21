using CyberResilience.Base;
using CyberResilience.BLL.AdminBLL;
using CyberResilience.BLL.LookupsBusinessLogic;
using CyberResilience.BLL.ServiceRequestsBusinessLogic;
using CyberResilience.Common.DTOs.ServiceRequestsDTO;
using CyberResilience.Mapper.WebMapper;
using CyberResilience.Models.FreeServicesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult QuickOnlineAssessment(int? type, int? subType)
        {
            if (!String.IsNullOrEmpty(base.CurrentUserName))
            {
                QuickOnlineAssessmentViewModel model = new QuickOnlineAssessmentViewModel();
                //model.TemplateTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", base.CurrentCulture);
                //model.TemplateSubTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", base.CurrentCulture);
                #region type checking
                if (type.HasValue)
                {
                    switch (type)
                    {
                        case (int)TemplateTypes.Toolkits:
                            type = (int)TemplateTypes.Toolkits;
                            break;
                        case (int)TemplateTypes.PolicyManagement:
                            type = (int)TemplateTypes.PolicyManagement;
                            break;
                        default:
                            type = (int)TemplateTypes.Quastionnaire;
                            break;
                    }
                }
                else
                {
                    type = (int)TemplateTypes.Quastionnaire;
                }
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
                #endregion
                model = mapper.ConvertQuickOnlineAssessmentToWeb(_TemplateBusinessLogic.GetTemplateByType(type.Value, subType.Value), base.CurrentCulture);
                //List<SelectListItem> items = new List<SelectListItem>();
                //var s = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ComplianceLevel", base.CurrentCulture);
                //foreach (var item in s)
                //{
                //    items.Add(new SelectListItem { Text = item.Value, Value = item.Id.ToString() });
                //}
                //ViewBag.ComplianceLevel = items;

                if (base.CurrentCulture == CyberResilience.Common.Enums.Culture.Arabic)
                {
                    model.Template = model.TemplateNameAr;
                    model.Type = _LookupsBusinessLogic.GetLookupByID(type.Value).ValueAr;
                    model.SubType = _LookupsBusinessLogic.GetLookupByID(subType.Value).ValueAr;
                }
                else
                {
                    model.Template = model.TemplateNameEn;
                    model.Type = _LookupsBusinessLogic.GetLookupByID(model.TemplateType).ValueEn;
                    model.SubType = _LookupsBusinessLogic.GetLookupByID(model.TemplateSubType).ValueEn;
                }
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
            model.CreatedBy = base.CurrentUserName;
            model.CreatedDate = DateTime.Now;
            model.ServicePaymentType = (int)PaymentType.FreeService;
            model.ServiceType = (int)ServiceType.QuastionnaireISO27001;
            model.ServiceRequestStatus = (int)ServiceRequestStatus.New;
            model.UserName = base.CurrentUserName;

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
        public ActionResult Test()
        {
            return View();
        }

    }
}