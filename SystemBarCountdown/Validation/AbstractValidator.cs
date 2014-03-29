using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBarCountdown.Validation
{
    abstract class AbstractValidator : Validator
    {
        private bool _isValid = false;
        private ValidationError _error = null;

        public string Value { set; get; }
        public bool IsValid { protected set { _isValid = value; } get { return _isValid; } }
        public ValidationError Error { protected set { _error = value; }  get { return _error; } }

        public abstract void Validate();
    }
}
