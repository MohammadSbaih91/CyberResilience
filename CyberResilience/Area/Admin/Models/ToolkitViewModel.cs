using CyberResilience.Common.DTOs.LookupsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.Area.Admin.Models
{
    public class ToolkitViewModel
    {
        public int Id { get; set; }
        public string ToolkitAttachmentType { get; set; }
        public string ToolkitAttachmentFileName { get; set; }
        public string caption { get; set; }
        public string contentType { get; set; }
        public byte[] data { get; set; }
        public int ToolkitType { get; set; }
        public string ToolkitName { get; set; }
        public string ToolkitArabicName { get; set; }
        public string ToolkitTypeName { get; set; }
        public HttpPostedFileBase File { get; set; }

        public List<ToolkitViewModel> Attachments { get; set; }
        public IEnumerable<LookupsDTO> toolkitTypes { get; set; }



        public override string ToString()
        {
            string urlToDownload = string.Empty;

            string template = "DownloadToolkit?id={0}";
            urlToDownload = string.Format(template, Id);

            return urlToDownload;
        }

        public string ToDelete()
        {
            string urlToDownload = string.Empty;

            string template = "DeleteToolkit?id={0}";
            urlToDownload = string.Format(template, Id);

            return urlToDownload;
        }


    }
}