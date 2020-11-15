using CyberResilience.Base;
using CyberResilience.BLL.AdminBLL;
using CyberResilience.BLL.LookupsBusinessLogic;
using CyberResilience.Mapper.WebMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberResilience.Area.Admin.Models;
using CyberResilience.BLL.AdminBLL.ToolkitsBusinessLogic;
using System.IO;

namespace CyberResilience.Area.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ToolkitController : BaseController
    {
        private LookupCategoryBusinessLogic _LookupCategoryBusinessLogic;
        private LookupsBusinessLogic _LookupsBusinessLogic;
        private TemplateBusinessLogic _TemplateBusinessLogic;
        private BaseQuestionsBusinessLogic _BaseQuestionsBusinessLogic;
        private QuestionsBusinessLogic _QuestionsBusinessLogic;
        private AttachmentsBusinessLogic _AttachmentsBusinessLogic;
        private ToolkitsBusinessLogic _ToolkitsBusinessLogic;

        private ToolkitsMapper mapper;

        public ToolkitController()
        {
            _LookupCategoryBusinessLogic = new LookupCategoryBusinessLogic();
            _LookupsBusinessLogic = new LookupsBusinessLogic();
            _TemplateBusinessLogic = new TemplateBusinessLogic();
            _BaseQuestionsBusinessLogic = new BaseQuestionsBusinessLogic();
            _QuestionsBusinessLogic = new QuestionsBusinessLogic();
            _AttachmentsBusinessLogic = new AttachmentsBusinessLogic();
            _ToolkitsBusinessLogic = new ToolkitsBusinessLogic();

            mapper = new ToolkitsMapper();
        }
        // GET: Toolkit
        public ActionResult Index()
        {
            ToolkitViewModel model = new ToolkitViewModel();
            model.toolkitTypes = _LookupCategoryBusinessLogic.GetLookupsByLookupCategoryCode("ToolkitTypes", base.CurrentCulture);
            model.Attachments = mapper.ConvertToolkitsToWeb(_ToolkitsBusinessLogic.GetAllToolkits());

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ToolkitViewModel model)
        {
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].FileName != "")
                {
                    string fileName = Request.Files[upload].FileName;
                    string extension = Request.Files[upload].ContentType;
                    string contentType = "";
                    switch (extension)
                    {
                        case "application/pdf":
                            contentType = ".pdf";
                            break;
                        case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                            contentType = ".xlsx";
                            break;
                        case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                            contentType = ".docx";
                            break;
                        // and so on
                        default:
                            contentType = extension;
                            break;
                            //throw new ArgumentOutOfRangeException($"Unable to find Content Type for file name {Request.Files[upload].FileName}.");
                    }

                    long fileLength = Request.Files[upload].InputStream.Length;
                    byte[] fileContent = new byte[fileLength];

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        Request.Files[upload].InputStream.CopyTo(memoryStream);

                        fileContent = memoryStream.ToArray();
                    }

                    model.caption = "toolkit";
                    model.data = fileContent;
                    model.ToolkitArabicName = model.ToolkitArabicName;
                    model.contentType = contentType;
                    model.ToolkitName = model.ToolkitName;
                    model.ToolkitType = model.ToolkitType;
                    ViewBag.IsAdded = true;
                }
            }
            var isAdded = _ToolkitsBusinessLogic.AddToolkit(mapper.ConvertToolkitToBLL(model));
            if (isAdded == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DownloadToolkit(int id)
        {
            ToolkitViewModel attachment = new ToolkitViewModel();
            attachment = mapper.ConvertToolkitToWeb(_ToolkitsBusinessLogic.GetToolkit(id));
            if (attachment != null && (attachment.data != null && attachment.data.Length > 0))
            {
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.ClearContent();
                response.Clear();
                response.ContentType = "text/plain";
                response.AddHeader("Content-Disposition", "inline; filename=" + attachment.ToolkitName + ";");
                new System.IO.MemoryStream(attachment.data).CopyTo(response.OutputStream);
                response.Flush();
                response.End();
            }

            return View();
        }

        [HttpGet]
        public ActionResult DeleteToolkit(int id)
        {
            var isDeleted = _ToolkitsBusinessLogic.DeleteToolkit(id);
            if (isDeleted == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}