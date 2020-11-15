using CyberResilience.Common.DTOs.Admin.ToolkitDTO;
using CyberResilience.Common.Utilities;
using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL.CustomRepositories
{
    public class ToolkitRepository : Repository<Toolkit>
    {
        public ToolkitRepository(UnitOfWork uow) : base(uow) { }
        public bool AddToolkit(ToolkitDTO dto)
        {
            try
            {
                var record = new Toolkit()
                {
                    caption = dto.caption,
                    contentType = dto.contentType,
                    data = dto.data,
                    attachmentType = dto.ToolkitAttachmentType,
                    ToolkitType = dto.ToolkitType,
                    fileNameAr = dto.ToolkitArabicName,
                    fileNameEn = dto.ToolkitName,
                    CreatedBy = "Sbaih",
                    CreatedDate = DateTime.Now,
                };
                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddToolkit", "An error occurred while trying to create Toolkit Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public ToolkitDTO GetToolkit(int toolkitId)
        {
            var toolkit = GetQuerable(x => x.Id == toolkitId).Select(u => new ToolkitDTO()
            {
                caption = u.caption,
                Id = u.Id,
                contentType = u.contentType,
                data = u.data,
                ToolkitArabicName = u.fileNameAr,
                ToolkitAttachmentType = u.attachmentType,
                ToolkitName = u.fileNameEn,
                ToolkitType = u.ToolkitType,

            }).FirstOrDefault();

            return toolkit;
        }
        public List<ToolkitDTO> GetToolkitsByType(int toolkitType)
        {
            var toolkits = GetQuerable(x => x.ToolkitType == toolkitType).Select(u => new ToolkitDTO()
            {
                caption = u.caption,
                Id = u.Id,
                contentType = u.contentType,
                data = u.data,
                ToolkitArabicName = u.fileNameAr,
                ToolkitAttachmentType = u.attachmentType,
                ToolkitName = u.fileNameEn,
                ToolkitType = u.ToolkitType,

            }).ToList();
            return toolkits;
        }

        public bool DeleteToolkit(int ToolkitId)
        {
            try
            {
                var toolkit = GetQuerable(x => x.Id == ToolkitId).FirstOrDefault();
                if (toolkit != null)
                {
                    Delete(toolkit);
                    _uow.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("DeleteToolkit", "An error occurred while trying to DeleteToolkit Record - BLL");
                Tracer.Error(ex);
                return false;
            }
        }
        public List<ToolkitDTO> GetAllToolkits()
        {
            var toolkits = GetQuerable(x => x.Id >= 1).Select(u => new ToolkitDTO()
            {
                caption = u.caption,
                Id = u.Id,
                contentType = u.contentType,
                data = u.data,
                ToolkitArabicName = u.fileNameAr,
                ToolkitAttachmentType = u.attachmentType,
                ToolkitName = u.fileNameEn,
                ToolkitType = u.ToolkitType,
                ToolkitTypeName = _db.LookupCultures.Where(x => x.LookupID == u.ToolkitType).Select(x => x.Value).FirstOrDefault(),

            }).ToList();
            return toolkits;
        }

    }
}
