//using CyberResilience.Base;
//using CyberResilience.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace CyberResilience.Controllers
//{
//    public class MessageController : BaseController
//    {
//        public ActionResult Success()
//        {
//            var message = TempDataManager.Get("SuccessMessage");
//            return View(message);
//        }

//        public ActionResult Error()
//        {
//            var message = TempDataManager.Get("ErrorMessage");

//            return View(message);
//        }
//        public ActionResult CustomMessage() //CustomMessagePageModel model)
//        {
//            //if (model == null)
//            //{
//            // Try to get from TempData
//            CustomMessagePageModel model = TempDataManager.Get("CustomMessagePageModel") as CustomMessagePageModel;
//            if (model == null)
//            {
//                model = new CustomMessagePageModel();
//            }
//            //}

//            if (!string.IsNullOrWhiteSpace(model.Message))
//            {
//                model.Message = Server.HtmlDecode(model.Message);
//            }
//            //if (model.Message != null)
//            //{
//            //    string message = model.Message.ToString();
//            //    model.Message = new System.Web.HtmlString(Server.HtmlDecode(message));
//            //}

//            return View(model);
//        }

//        public ActionResult RequestCreatedSuccessfully()
//        {
//            var message = TempDataManager.Get("CreatedRequestNumber");
//            if (message == null)
//            {
//                return RedirectToAction("Index", "Home");
//            }
//            return View(message);
//        }

//        //public string CheckErrorPageRefrehsedUsingAjax()
//        //{
//        //    if (Session["isrefreshed"] != null)
//        //    {
//        //        Session["isrefreshed"] = null;
//        //        if (Common.Helper.AppSettings.returnToSharepointSammPortal && AppSettings.IsFrontEnd)
//        //            return AppSettings.Urls.FrontendUrl;
//        //        else if (AppSettings.returnToSharepointSammPortal && !AppSettings.IsFrontEnd)
//        //            return AppSettings.Urls.BackendUrl;
//        //        else
//        //            return "/Home/Index";
//        //    }
//        //    Session["isrefreshed"] = "1";
//        //    return "0";

//        //}
//    }
//}