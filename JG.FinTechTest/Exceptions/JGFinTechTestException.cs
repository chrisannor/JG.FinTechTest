using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.Exceptions
{
    public class JGFinTechTestException : Exception
    {
        public readonly ErrorCode ErrorCode;

        public JGFinTechTestException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }

}
