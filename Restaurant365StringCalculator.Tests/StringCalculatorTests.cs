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
        [TestCase("1,5000", ExpectedResult = 5001)]
        [TestCase("1\n2,3", ExpectedResult = 6)]
        public int Add_ValidNumbers_ReturnsSum(string input)
        {
            return _calculator.Add(input);
        }
    }
}