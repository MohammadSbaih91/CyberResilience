using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CyberResilience.Common.Enums;

namespace CyberResilience.DAL.CustomRepositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(UnitOfWork uow) : base(uow) { }
        public bool IsUserActive(string AspNetUserId)
        {
            var user = GetQuerable(x => x.AspNetUserId == AspNetUserId).FirstOrDefault();
            if (user.StatusId == (int)UserStatus.ActiveUser)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
       

    }
}
