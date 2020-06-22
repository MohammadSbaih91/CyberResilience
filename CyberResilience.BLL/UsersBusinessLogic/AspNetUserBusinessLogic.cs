using CyberResilience.Common.DTOs.UsersDTO;
using CyberResilience.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.BLL.UsersBusinessLogic
{
    public class AspNetUserBusinessLogic
    {
      
        public string RegisterUser(UsersDTO user)
        {
            using (var uow = new UnitOfWork())
            {
                //string UserId = uow.AspNetUsers.RegisterUser(user);
                //return UserId;
                return "ss";
            }
        }

    }
}
