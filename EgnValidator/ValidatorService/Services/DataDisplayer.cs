using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorService
{
    public class DataDisplayer : IDataDisplayer
    {
        private IValidator _validator;

        public DataDisplayer(IValidator validator)
        {
            _validator = validator;
        }

        public string ValidationMessage(string egn)
        {
            if (!_validator.ValidateLength(egn))
                return Consts.LengthError;
            if (!_validator.ValidateIsAllDigits(egn))
                return Consts.DigitError;
            if (!_validator.ValidateMonths(egn))
                return Consts.InvalidMonth;
            if (!_validator.ValidateDates(egn))
                return Consts.InvalidDate;
            if (!_validator.ValidateLastDigit(egn))
                return Consts.InvalidLastDigit;

            return Consts.Success;
        }
    }
}
