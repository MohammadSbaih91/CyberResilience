using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL.CustomRepositories
{
    public class MandatoryValuesAndWeightRepository : Repository<MandatoryValuesAndWeight>
    {
        public MandatoryValuesAndWeightRepository(UnitOfWork uow) : base(uow) { }


    }
}
