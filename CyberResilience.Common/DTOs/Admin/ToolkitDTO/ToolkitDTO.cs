using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.Admin.ToolkitDTO
{
    public class ToolkitDTO
    {
        public int Id { get; set; }
        public string ToolkitAttachmentType { get; set; }
        public string ToolkitAttachmentFileName { get; set; }
        public string ToolkitTypeName { get; set; }
        public string caption { get; set; }
        public string contentType { get; set; }
        public byte[] data { get; set; }
        public int ToolkitType { get; set; }
        public string ToolkitName { get; set; }
        public string ToolkitArabicName { get; set; }
    }
}
