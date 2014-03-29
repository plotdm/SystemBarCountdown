using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBarCountdown
{
    enum ValidationErrorCode
    {
        ERROR_NOT_NUMBER
    }

    interface Validator
    {
        string Value { set; get; }
        bool IsValid { get; }
        ValidationError Error { get; }

        void Validate();
    }
}
