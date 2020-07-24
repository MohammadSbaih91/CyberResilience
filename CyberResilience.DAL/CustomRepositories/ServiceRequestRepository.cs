using CyberResilience.Common.DTOs.ServiceRequestsDTO;
using CyberResilience.Common.Utilities;
using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL.CustomRepositories
{
    public class ServiceRequestRepository : Repository<ServiceRequest>
    {
        public ServiceRequestRepository(UnitOfWork uow) : base(uow) { }
        public int CreateServiceRequest(ServiceRequestsDTO dto)
        {
            try
            {
                var record = new ServiceRequest()
                {
                    CreatedBy = dto.CreatedBy,
                    CreatedDate = dto.CreatedDate,
                    LastUpdateBy = dto.LastUpdateBy,
                    ServiceName = dto.ServiceName,
                    LastUpdateDate = dto.LastUpdateDate,
                    ServicePaymentType = dto.ServicePaymentType,
                    ServiceType = dto.ServiceType,
                    ServiceRequestStatus = dto.ServiceRequestStatus,
                    UserId = _uow.AspNetUsers.GetUserIdByUserName(dto.UserID),
                };
                Create(record);
                _uow.Save();
                return record.Id;
            }
            catch (Exception ex)
            {
                ex.Data.Add("CreateServiceRequest", "An error occurred while trying to Create Service Request ( Quastionnaire ) Record - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return 0;
            }
        }
        public List<UserServicesDTO> GetUserServices(string UserId)
        {
            var services = new List<UserServicesDTO>();
            try
            {
                services = GetQuerable(x => x.UserId == UserId).Include(x => x.ComplianceResults).Select(u => new UserServicesDTO()
                {
                    Id = u.Id,
                    CreatedBy = u.CreatedBy,
                    CreatedDate = u.CreatedDate,
                    LastUpdateBy = u.LastUpdateBy,
                    LastUpdateDate = u.LastUpdateDate,
                    ServiceName = u.ServiceName,
                    ServicePaymentType = u.ServicePaymentType,
                    ServiceRequestStatus = u.ServiceRequestStatus,
                    ServiceType = u.ServiceType,
                    UserID = u.UserId,
                    AssessmentResults = (from d in u.ComplianceResults
                                                  select new QuickOnlineAssessmentResultDTO()
                                                  {
                                                    CreatedBy=d.CreatedBy,
                                                    CreatedDate=d.CreatedDate,
                                                    Id=d.Id,
                                                    ImplementationPeriodAccurateExpectedTime=d.ImplementationPeriodAccurateExpectedTime,
                                                    ImplementationPeriodTime=d.ImplementationPeriodTime,
                                                    IsArchived=d.IsArchived,
                                                    IsDeleted=d.IsDeleted,
                                                    IsUpdated=d.IsUpdated,
                                                    QuestionCount=u.ComplianceResults.Count,
                                                  }).ToList(),
                }).ToList();
                return services;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetUserServices", "An error occurred while trying to Get User Services  Records - DAL");
                Tracer.Error(ex);
                _uow.Rollback();
                return null;
            }
        }
    }
}
