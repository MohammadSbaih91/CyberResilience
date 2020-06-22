﻿using CyberResilience.Common;
using CyberResilience.Common.DTOs.LookupsDTO;
using CyberResilience.DAL.Entities;
using CyberResilience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.DAL.CustomRepositories
{
    public class LookupCategoryRepository : Repository<LookupCategory>
    {
        public LookupCategoryRepository(UnitOfWork uow) : base(uow) { }
        public IEnumerable<LookupsDTO> GetLookupsByLookupCategoryCode(string lookupCategoryCode, Enums.Culture cul)
        {
            if (cul == 0) cul = Enums.Culture.Arabic;
            int language =(int) Enums.CultureID.Ar;
            if (cul == Enums.Culture.Arabic)
            {
                language = (int)Enums.CultureID.Ar;
            }
            else
            {
                language = (int)Enums.CultureID.En;
            }
            var repository = _uow.LookupCategory;
            var data = (from cat in _db.LookupCategories
                        join look in _db.Lookups on cat.Id equals look.CategoryId
                        join looCul in _db.LookupCultures on look.Id equals looCul.LookupID
                        join culture in _db.Cultures on looCul.CultureID equals culture.CultureID
                        where culture.CultureID == language && cat.FixedCode == lookupCategoryCode
                        select new LookupsDTO
                        {
                            Value = looCul.Value,
                            Id = looCul.LookupID,
                            LookupCode = looCul.Lookup.LookupCode,
                        }).ToList();

            if (data == null)
            {
                return null;
            }
            return data;
        }

    }
}
