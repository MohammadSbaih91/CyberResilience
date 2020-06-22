using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL.CustomRepositories
{
    public class RecomendedValuesAndWeightRepository : Repository<RecomendedValuesAndWeight>
    {
        public RecomendedValuesAndWeightRepository(UnitOfWork uow) : base(uow) { }


    }
}
