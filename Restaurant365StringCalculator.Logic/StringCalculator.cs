using Restaurant365StringCalculator.Logic.Interfaces;
using System.Text.RegularExpressions;

namespace Restaurant365StringCalculator.Logic
{
    public class StringCalculator : IStringCalculator
    {
        private readonly string[] _delimiters = new string[]{",", "\\n", "\n" };
        
        public int Add(string formattedNumber)
        {
            if (string.IsNullOrWhiteSpace(formattedNumber)) return 0;

            var numbers = formattedNumber.Split(_delimiters, StringSplitOptions.None).Select(n =>
            {
                return int.TryParse(n, out var num) ? num : 0;
            }).ToList();
            
            return numbers.Sum();
        }
    }
}