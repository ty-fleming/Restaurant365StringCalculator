using Restaurant365StringCalculator.Logic.Interfaces;
using Restaurant365StringCalculator.Logic;

namespace Restaurant365StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        private IStringCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new StringCalculator();
        }

        [Test]
        [TestCase("", ExpectedResult = 0)]
        [TestCase("20", ExpectedResult = 20)]
        [TestCase("1\n2,3", ExpectedResult = 6)]
        [TestCase("1\\n2,3", ExpectedResult = 6)]
        [TestCase("//#\n2#5", ExpectedResult = 7)]
        [TestCase("//,\\n2,ff,100", ExpectedResult = 102)]
        [TestCase("//[***]\\n11***22***33", ExpectedResult = 66)]
        [TestCase("//[*][!!][r9r]\\n11r9r22*hh*33!!44", ExpectedResult = 110)]
        public int AddNumbers_Success(string input)
        {
            return _calculator.Add(input);
        }


        [Test]
        [TestCase("1,5000", ExpectedResult = 1)]
        [TestCase("2,1001,6", ExpectedResult = 8)]
        public int AddNumbers_SkipOver1000_Success(string input)
        {
            return _calculator.Add(input);
        }

        [Test]
        public void AddNumbers_IncludesNegative_ThrowsException()
        {
            var exception = Assert.Throws<Exception>(() => _calculator.Add("130,-32387"));
            Assert.That(exception.Message, Is.EqualTo("Negative numbers are not allowed in the input. Please remove all negative numbers and try again. -32387"));
        }
    }
}