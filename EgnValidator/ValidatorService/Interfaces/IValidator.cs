using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorService
{
    public interface IValidator
    {
        bool ValidateLength(string egn);

        bool ValidateIsAllDigits(string egn);

        bool ValidateMonths(string egn);

        bool ValidateDates(string egn);

        bool ValidateLastDigit(string egn);
    }
}
