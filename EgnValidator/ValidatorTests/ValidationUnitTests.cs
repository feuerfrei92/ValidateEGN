using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorService;

namespace ValidatorTests
{
    [TestClass]
    public class ValidationUnitTests
    {
        private IValidator _validator;

        public ValidationUnitTests()
        {
            _validator = new Validator();
        }

        [TestMethod]
        public void TestMethod_ValidateLength_Correct()
        {
            string egn = "1234567890";

            bool result = _validator.ValidateLength(egn);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod_ValidateLength_Incorrect()
        {
            string egn = "123456789";

            bool result = _validator.ValidateLength(egn);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod_ValidateIsAllDigits_Correct()
        {
            string egn = "1234567890";

            bool result = _validator.ValidateIsAllDigits(egn);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod_ValidateIsAllDigits_Incorrect()
        {
            string egn = "1234p67890";

            bool result = _validator.ValidateIsAllDigits(egn);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod_ValidateMonths_Correct()
        {
            string egn = "1212567890";

            bool result = _validator.ValidateMonths(egn);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod_ValidateMonths_Incorrect()
        {
            string egn = "1234567890";

            bool result = _validator.ValidateMonths(egn);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod_ValidateDates_Correct()
        {
            string egn = "1202297890";

            bool result = _validator.ValidateDates(egn);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod_ValidateDates_Incorrect()
        {
            string egn = "1402297890";

            bool result = _validator.ValidateDates(egn);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod_ValidateLastDigit_Correct()
        {
            string egn = "8812102466";

            bool result = _validator.ValidateLastDigit(egn);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod_ValidateLastDigit_Incorrect()
        {
            string egn = "8812102461";

            bool result = _validator.ValidateLastDigit(egn);

            Assert.IsFalse(result);
        }
    }
}
