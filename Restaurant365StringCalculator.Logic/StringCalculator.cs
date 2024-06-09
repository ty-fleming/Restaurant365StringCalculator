using Restaurant365StringCalculator.Logic.Interfaces;
using System.Text.RegularExpressions;

namespace Restaurant365StringCalculator.Logic
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string formattedNumber)
        {
            if (string.IsNullOrWhiteSpace(formattedNumber)) return 0;

            var numbers = formattedNumber.Split(',').Select(n =>
            {
                return int.TryParse(n, out var num) ? num : 0;
            }).ToList();

            if (numbers.Count > 2)
            {
                throw new Exception("More than two numbers provided");
            }
            
            return numbers.Sum();
        }
    }
}