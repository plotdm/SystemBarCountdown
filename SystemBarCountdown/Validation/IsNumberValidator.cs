using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBarCountdown.Validation
{
    class IsNumberValidator : AbstractValidator
    {
        public override void Validate()
        {
            var value = Value.Trim();
            double num;
            bool isNum = double.TryParse(value, out num);
            IsValid = isNum;
            if (!IsValid)
            {
                Error = new ValidationError(ValidationErrorCode.ERROR_NOT_NUMBER, "Value must be number");
            }
        }
    }
}
