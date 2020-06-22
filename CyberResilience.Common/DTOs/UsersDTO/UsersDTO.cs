using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.DTOs.UsersDTO
{
    public class UsersDTO
    {
        public int Id { get; set; }

        public string FirstNameAr { get; set; }

        public string FirstNameEn { get; set; }

        public string LastNameAr { get; set; }

        public string LastNameEn { get; set; }

        public bool IsComplete { get; set; }

        public bool IsChangePasswordRequired { get; set; }

        public bool IsChangeUsernameRequired { get; set; }

        public string NationalityNumber { get; set; }

        public DateTime? IdCardExpieryDate { get; set; }

        public string IdCardImageURL { get; set; }

        public string PassportId { get; set; }

        public DateTime? PassportExpieryDate { get; set; }

        public string PassportImageURL { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ProfileImageURL { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string PostOffice { get; set; }

        public string Address { get; set; }

        public int? ChannelId { get; set; }

        public int? AccountTypeId { get; set; }

        public int? GenderId { get; set; }

        public int? IdCard { get; set; }

        public int? NationalityId { get; set; }

        public int? SocialId { get; set; }

        public string AspNetUserId { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public int LoginAttempts { get; set; }

        public string VerificationCode { get; set; }

        public bool MobileNeedsVerification { get; set; }

        public string MobileVerificationCode { get; set; }

        public int StatusId { get; set; }

        public bool? FirstTimeRegister { get; set; }

        public bool? IsBlocked { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}
