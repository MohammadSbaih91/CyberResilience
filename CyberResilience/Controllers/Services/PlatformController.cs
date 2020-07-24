using CyberResilience.Base;
using CyberResilience.BLL.AdminBLL;
using CyberResilience.BLL.LookupsBusinessLogic;
using CyberResilience.BLL.ServiceRequestsBusinessLogic;
using CyberResilience.Mapper.WebMapper;
using CyberResilience.Models.FreeServicesViewModel;
using CyberResilience.Models.PlatformViewModel;
using CyberResilience.UIHelper.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CyberResilience.Controllers.Services
{
    [Authorize(Roles = "RegisteredUser, Employee, Admin")]
    public class PlatformController : BaseController
    {
        private LookupCategoryBusinessLogic _LookupCategoryBusinessLogic;
        private LookupsBusinessLogic _LookupsBusinessLogic;
        private ServiceRequestBusinessLogic _ServiceRequestBusinessLogic;
        private TemplateBusinessLogic _TemplateBusinessLogic;
        private FreeServicesMapper mapper;
        public PlatformController()
        {
            _LookupCategoryBusinessLogic = new LookupCategoryBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
            _ServiceRequestBusinessLogic = new ServiceRequestBusinessLogic();
            _TemplateBusinessLogic = new TemplateBusinessLogic();
            mapper = new FreeServicesMapper();
        }
        // GET: Platform
        [Authorize(Roles = "RegisteredUser, Employee, Admin")]
        public ActionResult Index()
        {
            if (!String.IsNullOrEmpty(base.CurrentUserName))
            {
                int totalRecords = 0;
                int page = 1;
                int pageSize = 10;
                var Services = mapper.ConvertUserServicesToWeb(_ServiceRequestBusinessLogic.GetUserServices(base.CurrentUserName, out totalRecords, page, pageSize), base.CurrentCulture);
                PlatformViewModel model = new PlatformViewModel();
                List<ServiceRequestViewModel> List = new List<ServiceRequestViewModel>();
                List<QuickOnlineAssessmentResultViewModel> AssessmentResultList = new List<QuickOnlineAssessmentResultViewModel>();



                var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");
                var urlAssessmentStringFormat = string.Format("{0}?page={1}", Url.Action("LoadAssessmentResultsPage"), "{0}");
                List = Services;
                foreach (var item in Services)
                {
                    foreach (var subItem in item.AssessmentResults)
                    {
                        AssessmentResultList.Add(subItem);
                    }
                }
                var AssessmentResultsPagedList = AssessmentResultList.ToPagedListModel(totalRecords, page, pageSize, urlAssessmentStringFormat);
                var pagedList = List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);
                model.Services = pagedList;
                model.AssessmentResults = AssessmentResultsPagedList;

                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        #region Services
        private IEnumerable<ServiceRequestViewModel> GetServices(out int totalRecords, int page = 1, int pageSize = 10)
        {
            List<ServiceRequestViewModel> List = new List<ServiceRequestViewModel>();
            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");

            var Services = mapper.ConvertUserServicesToWeb(_ServiceRequestBusinessLogic.GetUserServices(base.CurrentUserName, out totalRecords, page, pageSize), base.CurrentCulture);
            List = Services;

            return List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);


        }
        public ActionResult LoadResultsPage(int page = 1)
        {
            int totalRecords;
            var pagedList = GetServices(out totalRecords, page, 10);
            // get the corresponding page for the results table            
            return PartialView("~/Views/Shared/Partials/Platform/_ServicesList.cshtml", pagedList);
        }
        #endregion
        #region Assessment Results
        private IEnumerable<QuickOnlineAssessmentResultViewModel> GetAssessmentResults(out int totalRecords, int page = 1, int pageSize = 10)
        {
            List<QuickOnlineAssessmentResultViewModel> List = new List<QuickOnlineAssessmentResultViewModel>();
            var urlStringFormat = string.Format("{0}?page={1}", Url.Action("LoadResultsPage"), "{0}");
            var Services = mapper.ConvertUserServicesToWeb(_ServiceRequestBusinessLogic.GetUserServices(base.CurrentUserName, out totalRecords, page, pageSize), base.CurrentCulture);
            foreach (var item in Services)
            {
                foreach (var subItem in item.AssessmentResults)
                {
                    List.Add(subItem);
                }
            }
            return List.ToPagedListModel(totalRecords, page, pageSize, urlStringFormat);
        }
        public ActionResult LoadAssessmentResultsPage(int page = 1)
        {
            int totalRecords;
            var pagedList = GetAssessmentResults(out totalRecords, page, 10);
            // get the corresponding page for the results table            
            return PartialView("~/Views/Shared/Partials/Platform/_AssessmentResults.cshtml", pagedList);
        }
        #endregion
    }
}