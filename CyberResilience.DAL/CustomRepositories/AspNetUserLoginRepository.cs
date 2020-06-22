using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL.CustomRepositories
{
    public class AspNetUserLoginRepository : Repository<AspNetUserLogin>
    {

        public AspNetUserLoginRepository(UnitOfWork uow) : base(uow) { }
    }
}
