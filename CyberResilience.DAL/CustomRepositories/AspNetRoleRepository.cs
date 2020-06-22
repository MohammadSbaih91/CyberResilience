using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL.CustomRepositories
{
    public class AspNetRoleRepository : Repository<AspNetRole>
    {
        public AspNetRoleRepository(UnitOfWork uow) : base(uow) { }

        public List<string> GetRolesByUserName(string userName)
        {
            List<string> roles;


            roles = GetQuerable(u => u.AspNetUsers.Any(x=>x.UserName==userName)).Select(x => x.Name)
                   .ToList();
            return roles;
        }

    }
}
