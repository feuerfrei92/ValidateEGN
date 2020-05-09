using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidatorService
{
    public class Validator : IValidator
    {
        private Dictionary<int, int> _keyValueCollection = new Dictionary<int,int>();

        public bool ValidateLength(string egn)
        {
            return egn.Length == 10;
        }

        public bool ValidateIsAllDigits(string egn)
        {
            var regex = new Regex("^[0-9]+$");
            return regex.IsMatch(egn);
        }

        public bool ValidateMonths(string egn)
        {
            string monthString = egn.Substring(2, 2);
            int month;
            bool success = int.TryParse(monthString, out month) && month > 0 && month < 13;
            return success;
        }

        public bool ValidateDates(string egn)
        {
            string yearString = egn.Substring(0, 2);
            int year = int.Parse(yearString);
            PopulateDaysInMonths(year % 4 == 0);
            string monthString = egn.Substring(2, 2);
            int month = int.Parse(monthString);
            string dateString = egn.Substring(4, 2);
            int date;
            bool success = int.TryParse(dateString, out date) && date > 0 && date <= _keyValueCollection[month];
            return success;
        }

        public bool ValidateLastDigit(string egn)
        {
            PopulateWeightsForDigit();
            int digit, sum = 0;
            for (int i = 0; i < 9; i++)
            {
                digit = int.Parse(egn.Substring(i, 1));
                sum += digit * _keyValueCollection[i + 1];
            }

            digit = int.Parse(egn.Substring(9, 1));
            bool success = (sum % 11 == digit || ((sum % 11 == 0 || sum % 11 == 10) && digit == 0));
            return success;
        }

        private void PopulateDaysInMonths(bool isLeap)
        {
            _keyValueCollection.Clear();
            _keyValueCollection.Add(1, 31);
            if (isLeap)
            {
                _keyValueCollection.Add(2, 29);
            }
            else
            {
                _keyValueCollection.Add(2, 28);
            }
            _keyValueCollection.Add(3, 31);
            _keyValueCollection.Add(4, 30);
            _keyValueCollection.Add(5, 31);
            _keyValueCollection.Add(6, 30);
            _keyValueCollection.Add(7, 31);
            _keyValueCollection.Add(8, 31);
            _keyValueCollection.Add(9, 30);
            _keyValueCollection.Add(10, 31);
            _keyValueCollection.Add(11, 30);
            _keyValueCollection.Add(12, 31);
        }

        private void PopulateWeightsForDigit()
        {
            _keyValueCollection.Clear();
            _keyValueCollection.Add(1, 2);
            _keyValueCollection.Add(2, 4);
            _keyValueCollection.Add(3, 8);
            _keyValueCollection.Add(4, 5);
            _keyValueCollection.Add(5, 10);
            _keyValueCollection.Add(6, 9);
            _keyValueCollection.Add(7, 7);
            _keyValueCollection.Add(8, 3);
            _keyValueCollection.Add(9, 6);
        }
    }
}
