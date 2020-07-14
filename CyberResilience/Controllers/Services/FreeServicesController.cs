using CyberResilience.Base;
using CyberResilience.BLL.AdminBLL;
using CyberResilience.BLL.LookupsBusinessLogic;
using CyberResilience.BLL.ServiceRequestsBusinessLogic;
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
    public class FreeServicesController : BaseController
    {
        private LookupCategoryBusinessLogic _LookupCategoryBusinessLogic;
        private LookupsBusinessLogic _LookupsBusinessLogic;
        private ServiceRequestBusinessLogic _ServiceRequestBusinessLogic;
        private TemplateBusinessLogic _TemplateBusinessLogic;
        private FreeServicesMapper Mapper;
        public FreeServicesController()
        {
            _LookupCategoryBusinessLogic = new LookupCategoryBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
            _ServiceRequestBusinessLogic = new ServiceRequestBusinessLogic();
            _TemplateBusinessLogic = new TemplateBusinessLogic();
            Mapper = new FreeServicesMapper();
        }
        // GET: FreeServices
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult QuickOnlineAssessment(int? type, int? subType)
        {
            QuickOnlineAssessmentViewModel model = new QuickOnlineAssessmentViewModel();
            //model.TemplateTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateType", base.CurrentCulture);
            //model.TemplateSubTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("TemplateSubType", base.CurrentCulture);
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
            model = Mapper.ConvertQuickOnlineAssessmentToWeb(_TemplateBusinessLogic.GetTemplateByType(type.Value, subType.Value /*, base.CurrentCulture*/));
            if(base.CurrentCulture== CyberResilience.Common.Enums.Culture.Arabic)
            {
                model.Template =model.TemplateNameAr;
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
        [HttpPost]
        public ActionResult QuickOnlineAssessment(QuickOnlineAssessmentViewModel model)
        {
            model.CreatedBy = base.CurrentUserName;
            model.CreatedDate = DateTime.Now;
            model.ServicePaymentType = (int)PaymentType.FreeService;
            model.ServiceType = (int)ServiceType.QuastionnaireISO27001;
            model.ServiceRequestStatus = (int)ServiceRequestStatus.New;
            model.UserName = base.CurrentUserName;
            if (ModelState.IsValid)
            {
            bool IsAdded = _ServiceRequestBusinessLogic.CreateServiceRequest(Mapper.ConvertQuickOnlineAssessmentToBLL(model));

            }
                return View();
        }



    }
}