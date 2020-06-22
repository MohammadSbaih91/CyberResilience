using CyberResilience.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.BLL.UsersBusinessLogic
{
  public  class AspNetRolesBusinessLogic
    {
        public List<string> GetRolesByUserName(string userName)
        {
            List<string> roles;
            //if (AppSettings.IsFrontEnd)
            //{
            using (var uow = new UnitOfWork())
            {
                roles = uow.Roles.GetRolesByUserName(userName);
                return roles;
            }
        }
    }
}
