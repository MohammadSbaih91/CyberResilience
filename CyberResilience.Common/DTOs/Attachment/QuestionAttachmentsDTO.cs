using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CyberResilience.Common.DTOs.Attachment
{
   public class QuestionAttachmentsDTO
    {
        public int Id { get; set; }
        //[Display(Name = "file_stream", ResourceType = typeof(Resource))]
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
    }
}
