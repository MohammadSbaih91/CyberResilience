using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common
{
    public class Enums
    {
        public enum ComplianceLevel
        {
            NotUnderstanding=15,
            NotExist=16,
            ExistInPractice=17,
            ExistAndImplemntingWithoutAuditing=18,
            StrictlyComplyWithStandard=19
        }

        public enum AssessmentValuesWeight
        {
            MandatoryWeight=33,
            RecomendedWeight=34,
        }
        public enum PaymentType
        {
            FreeService = 20,
            NormalPaidService = 21,
            PremiumPaidService = 22
        }
        public enum ServiceType
        {
            QuastionnaireISO27001 = 24,
            QuastionnaireISO24001 = 25,
            QuastionnaireECC = 25,
            QuastionnaireSAMA=26
        }
        public enum ServiceRequestStatus
        {
            New = 29,
            UnderProccessing = 30,
            WaitingPayment = 31,
            Finished = 32
        }
        public enum TemplateTypes
        {
            Quastionnaire=7,
            Toolkits=8,
            PolicyManagement=9
        }
        public enum TemplateSubTypes
        {
            ISO27=10,
            ISO24=12,
            ECC=13,
            SAMA=14
        }
        public enum CommunicationType
        {
            EMail = 6,
            SMS = 5
        }
        public enum CultureID
        {
            Ar = 1,
            En = 2,
        }

        public enum Culture
        {
            Arabic = 9,
            English = 10
        }
        public enum UserType
        {
            Administrator = 2,
            Authority = 3,
            Registerd = 1,
            Anonymous = 5
        }
        public enum ApplicationTypes
        {
            FrontendApp = 1,
            BackendApp = 2,
            MobileApllication = 3,
            Morasalat = 4
        }
        public enum UserRole
        {
            RegisteredUser = 1,
            Admin = 2,
            Employee = 3,
            AnonymousUser = 4,
        }
        public enum UserStatus
        {
            ActiveUser = 3,
            StoppedUser = 4,
            RegistredUser = 5,
            DeletedUser = 6,
        }
    }
}
