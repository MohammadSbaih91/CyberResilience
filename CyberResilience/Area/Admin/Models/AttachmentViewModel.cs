using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberResilience.Area.Admin.Models
{
    public class AttachmentViewModel
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public long AttachmentID { get; set; }
        public string FileName { get; set; }
        public string Caption { get; set; }
        public string ContentType { get; set; }
        public string FileNameWithExtension { get; set; }
        public byte[] Data { get; set; }
        public long AttachmentId { get; set; }


        public override string ToString()
        {
            string urlToDownload = string.Empty;

            string template = "DownloadAttachment?id={0}";
            urlToDownload = string.Format(template, Id);

            return urlToDownload;
        }

        public string ToDelete()
        {
            string urlToDownload = string.Empty;

            string template = "DeleteAttachment?id={0}&TemplateId={1}";
            urlToDownload = string.Format(template, Id, TemplateId);

            return urlToDownload;
        }

        public string ToAttachmentToString()
        {
            string urlToDownload = string.Empty;

            string template = "DownloadAttachment?id={0}";
            urlToDownload = string.Format(template, Id);

            return urlToDownload;
        }

        public string ToAttachmentToDelete()
        {
            string urlToDownload = string.Empty;

            string template = "DeleteQuestionAttachment?id={0}&TemplateId={1}";
            urlToDownload = string.Format(template, Id, TemplateId);

            return urlToDownload;
        }

    }
}