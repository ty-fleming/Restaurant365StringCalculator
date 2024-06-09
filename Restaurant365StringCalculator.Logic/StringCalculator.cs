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

            var numbers = formattedNumber.Split(_delimiters, StringSplitOptions.None).Select(GetNumberFromString).ToList();

            var negativeNumbers = numbers.Where(n => n < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new Exception(
                    $"Negative numbers are not allowed in the input. Please remove all negative numbers and try again. {string.Join(", ", negativeNumbers)}");
            }
            
            return numbers.Sum();
        }

        private int GetNumberFromString(string numberToParse)
        {
            if (int.TryParse(numberToParse, out var number) && !IsInvalidNumber(number))
            {
                return number;
            }

            return 0;
        }

        private bool IsInvalidNumber(int numberToValidate)
        {
            return numberToValidate > 1000;
        }
    }
}