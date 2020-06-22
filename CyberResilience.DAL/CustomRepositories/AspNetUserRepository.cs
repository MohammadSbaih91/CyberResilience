using CyberResilience.Common.DTOs.UsersDTO;
using CyberResilience.Common.Utilities;
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
    public class AspNetUserRepository : Repository<AspNetUser>
    {
        public AspNetUserRepository(UnitOfWork uow) : base(uow) { }
        public AspNetUser GetUserByName(string userName)
        {
            var user = GetQuerable(x => x.UserName.Trim().ToLower() == userName.Trim().ToLower()).FirstOrDefault();
            return user;
        }
        public bool IsAlreadyRegistered(string SerialNumber)
        {
            var user = GetQuerable(x => x.Id.Trim() == SerialNumber.Trim()).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      

        public string RegisterUser(AspNetUserDTO user)
        {
            try
            {
                var record = new AspNetUser()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    PasswordHash = user.PasswordHash,
                };
                Create(record);
                _uow.Save();
                //record.AspNetRoles.Add(new AspNetRole() { Id=(int)UserRole.Admin});
                if (!string.IsNullOrEmpty(record.Id))
                {
                    return record.Id;
                }
                return null;
            }
            catch (Exception ex)
            {
                Tracer.Error(ex);
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" + ex.Message);
                return "";
            }

        }







    }
}
