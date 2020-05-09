using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ValidatorService;
using ValidatorUI;

namespace ValidatorTests
{
    [TestClass]
    public class DisplayerUnitTests
    {
        private Mock<IValidator> _moqValidator;
        private IDataDisplayer _displayer;

        public DisplayerUnitTests()
        {
            _moqValidator = new Mock<IValidator>();
        }

        [TestMethod]
        public void TestMethod_Validate_AllCorrect()
        {
            string egn = "8812102461";
            string expectedString = Consts.Success;
            _moqValidator.Setup(m => m.ValidateLength(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateIsAllDigits(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateMonths(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateDates(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateLastDigit(egn)).Returns(true);
            _displayer = new DataDisplayer(_moqValidator.Object);

            string validationMessage = _displayer.ValidationMessage(egn);

            _moqValidator.Verify();
            Assert.AreEqual(expectedString, validationMessage);
        }

        [TestMethod]
        public void TestMethod_ValidateLength_Incorrect()
        {
            string egn = "123456789";
            string expectedString = Consts.LengthError;
            _moqValidator.Setup(m => m.ValidateLength(egn)).Returns(false);
            _displayer = new DataDisplayer(_moqValidator.Object);

            string validationMessage = _displayer.ValidationMessage(egn);

            _moqValidator.Verify();
            Assert.AreEqual(expectedString, validationMessage);
        }

        [TestMethod]
        public void TestMethod_ValidateDigits_Incorrect()
        {
            string egn = "1234567p89";
            string expectedString = Consts.DigitError;
            _moqValidator.Setup(m => m.ValidateLength(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateIsAllDigits(egn)).Returns(false);
            _displayer = new DataDisplayer(_moqValidator.Object);

            string validationMessage = _displayer.ValidationMessage(egn);

            _moqValidator.Verify();
            Assert.AreEqual(expectedString, validationMessage);
        }

        [TestMethod]
        public void TestMethod_ValidateMonths_Incorrect()
        {
            string egn = "1234567890";
            string expectedString = Consts.InvalidMonth;
            _moqValidator.Setup(m => m.ValidateLength(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateIsAllDigits(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateMonths(egn)).Returns(false);
            _displayer = new DataDisplayer(_moqValidator.Object);

            string validationMessage = _displayer.ValidationMessage(egn);

            _moqValidator.Verify();
            Assert.AreEqual(expectedString, validationMessage);
        }

        [TestMethod]
        public void TestMethod_ValidateDates_Incorrect()
        {
            string egn = "1212567890";
            string expectedString = Consts.InvalidDate;
            _moqValidator.Setup(m => m.ValidateLength(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateIsAllDigits(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateMonths(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateDates(egn)).Returns(false);
            _displayer = new DataDisplayer(_moqValidator.Object);

            string validationMessage = _displayer.ValidationMessage(egn);

            _moqValidator.Verify();
            Assert.AreEqual(expectedString, validationMessage);
        }

        [TestMethod]
        public void TestMethod_ValidateLastDigit_Incorrect()
        {
            string egn = "8812102465";
            string expectedString = Consts.InvalidLastDigit;
            _moqValidator.Setup(m => m.ValidateLength(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateIsAllDigits(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateMonths(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateDates(egn)).Returns(true);
            _moqValidator.Setup(m => m.ValidateLastDigit(egn)).Returns(false);
            _displayer = new DataDisplayer(_moqValidator.Object);

            string validationMessage = _displayer.ValidationMessage(egn);

            _moqValidator.Verify();
            Assert.AreEqual(expectedString, validationMessage);
        }

        [TestMethod]
        public void TestMethod_Validate_StopAtFirstError()
        {
            string egn = "jgfhsdgf";
            string expectedString = Consts.LengthError;
            _moqValidator.Setup(m => m.ValidateLength(egn)).Returns(false);
            _moqValidator.Setup(m => m.ValidateIsAllDigits(egn)).Returns(false);
            _moqValidator.Setup(m => m.ValidateMonths(egn)).Returns(false);
            _moqValidator.Setup(m => m.ValidateDates(egn)).Returns(false);
            _moqValidator.Setup(m => m.ValidateLastDigit(egn)).Returns(false);
            _displayer = new DataDisplayer(_moqValidator.Object);

            string validationMessage = _displayer.ValidationMessage(egn);

            _moqValidator.Verify();
            Assert.AreEqual(expectedString, validationMessage);
        }
    }
}
