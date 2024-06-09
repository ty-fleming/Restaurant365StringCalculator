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
        public void Add_TwoNumbers()
        {
            Assert.That(_calculator.Add("1,5000"), Is.EqualTo(5001));
        }

        [Test]
        public void Add_MoreThanTwoNumbers()
        {
            Assert.That(_calculator.Add("1,2,3,4,5,6,7,8,9,10,11,12"), Is.EqualTo(78));
        }
    }
}