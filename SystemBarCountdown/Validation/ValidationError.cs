using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBarCountdown
{
    class ValidationError
    {
        private ValidationErrorCode _code;
        private string _message;

        public ValidationErrorCode Code { get { return _code; } }
        public string Message { get { return _message; } }

        public ValidationError(ValidationErrorCode code, string message)
        {
            _code = code;
            _message = message;
        }
    }
}
