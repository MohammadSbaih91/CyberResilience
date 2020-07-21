using CyberResilience.Common.DTOs.ServiceRequestsDTO;
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
                    UserId =_uow.AspNetUsers.GetUserIdByUserName(dto.UserID),
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





    }
}
