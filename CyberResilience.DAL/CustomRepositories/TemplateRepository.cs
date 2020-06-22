using CyberResilience.Common.DTOs.Admin;
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
    public class TemplateRepository : Repository<Template>
    {
        public TemplateRepository(UnitOfWork uow) : base(uow) { }
        public bool AddTemplate(TemplateDTO dto)
        {
            try
            {
                var record = new Template()
                {
                    TemplateNameAr = dto.TemplateNameAr,
                    TemplateNameEn = dto.TemplateNameEn,
                    TemplateSubType = dto.TemplateSubType,
                    TemplateType = dto.TemplateType,
                };

                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddTemplate", "An error occurred while trying to create Template Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return false;
            }
        }
        public List<TemplateDTO> GetAllTemplates()
        {
            var templates = new List<TemplateDTO>();
            try
            {
                templates = GetQuerable(x => x.Id >= 1).Select(u => new TemplateDTO()
                {
                    Id = u.Id,
                    TemplateNameAr = u.TemplateNameAr,
                    TemplateNameEn = u.TemplateNameEn,
                    TemplateSubType = u.TemplateSubType,
                    TemplateType = u.TemplateType,
                }).ToList();

                return templates;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetAllTemplates", "An error occurred while trying to get Templates Records - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }


        public List<TemplateDTO> GetTemplatesDropDownData()
        {
            var templates = new List<TemplateDTO>();
            try
            {
                templates = GetQuerable(x => x.Id >= 1).Select(u => new TemplateDTO()
                {
                    Id = u.Id,
                    TemplateNameAr = u.TemplateNameAr,
                    TemplateNameEn = u.TemplateNameEn,
                }).ToList();
                return templates;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetTemplatesDropDownData", "An error occurred while trying to get Templates in drop down Records - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return null;
            }
        }

        public TemplateDTO GetTemplate(int TemplateId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == TemplateId).Select(u => new TemplateDTO()
                {
                    Id = u.Id,
                    TemplateNameAr = u.TemplateNameAr,
                    TemplateNameEn = u.TemplateNameEn,
                    TemplateSubType = u.TemplateSubType,
                    TemplateType = u.TemplateType,
                }).FirstOrDefault();

                return record;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Template ", "An error occurred while trying to Get Template record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return null;
            }
        }
        public bool EditTemplate(TemplateDTO dto)
        {
            try
            {
                var record = GetQuerable(x => x.Id == dto.Id).FirstOrDefault();
                record.TemplateNameAr = dto.TemplateNameAr;
                record.TemplateNameEn = dto.TemplateNameEn;
                record.TemplateSubType = dto.TemplateSubType;
                record.TemplateType = dto.TemplateType;
                Update(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Template ", "An error occurred while trying to Update Template record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteTemplate(int TemplateId)
        {
            try
            {
                var record = GetQuerable(x => x.Id == TemplateId).FirstOrDefault();
                if (record != null)
                {
                    Delete(record);
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
                ex.Data.Add("Template ", "An error occurred while trying to Delete Template record  in DAL ");
                Tracer.Error(ex);
                _uow.Rollback();
                return false;
            }
        }
    }
}
