using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberResilience.DAL;
using CyberResilience.Common.DTOs.UsersDTO;

namespace CyberResilience.BLL.UsersBusinessLogic
{
    public class UsersBusinessLogic
    {
        public AspNetUserDTO GetUserByName(string userName)
        {
            using (var uow = new UnitOfWork())
            {

                var userEntity = uow.AspNetUsers.GetUserByName(userName);
                var user = new AspNetUserDTO()
                {
                    Id = userEntity.Id,
                    UserName = userEntity.UserName,
                    Email = userEntity.Email,
                    EmailConfirmed = userEntity.EmailConfirmed ,
                    AccessFailedCount = userEntity.AccessFailedCount,
                };
                return user;
            }
        }
        public bool IsUserActive(string AspNetUserId)
        {
            using (var uow = new UnitOfWork())
            {
                bool isActive = uow.Users.IsUserActive(AspNetUserId);
                return isActive;
            }
        }
    }
}
