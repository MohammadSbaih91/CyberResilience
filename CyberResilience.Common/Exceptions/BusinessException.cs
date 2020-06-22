using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberResilience.Common.Exceptions
{
    /// <summary>
    /// Represents a business exception that has an
    /// error message and error code
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message, int errorCode) : base($"Error:{errorCode} - {message}")
        {
            Code = errorCode;
        }

        public int Code
        {
            get; private set;
        }
    }
}
