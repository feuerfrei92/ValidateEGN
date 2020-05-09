using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorService
{
    public static class Consts
    {
        public const string LengthError = "Length must be 10";
        public const string DigitError = "Not all characters are digits";
        public const string InvalidMonth = "Month is not valid";
        public const string InvalidDate = "Date is not valid";
        public const string InvalidLastDigit = "Last digit is incorrect";
        public const string Success = "Valid EGN";
        public const int MAX_MONTH = 53;
    }
}
