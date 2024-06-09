using Restaurant365StringCalculator.Logic.Interfaces;
using System.Text.RegularExpressions;

namespace Restaurant365StringCalculator.Logic
{
    public class StringCalculator : IStringCalculator
    {
        private readonly string[] _newLineDelimiters = { "\\n", "\n" };
        private readonly string[] _defaultDelimiters = new string[]{};

        public StringCalculator()
        {
            _defaultDelimiters = new [] { "," }.Concat(_newLineDelimiters).ToArray();
        }
        
        public int Add(string formattedNumber)
        {
            if (string.IsNullOrWhiteSpace(formattedNumber))
            {
                return 0;
            }

            var delimiters = _defaultDelimiters.ToList();
            if (TryParseCustomDelimiterTemplate(formattedNumber, out string customDelimiter))
            { 
                delimiters.Add(customDelimiter!);
            }

            var numbers = formattedNumber.Split(delimiters.ToArray(), StringSplitOptions.None).Select(GetNumberFromString).ToList();

            var negativeNumbers = numbers.Where(n => n < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new Exception(
                    $"Negative numbers are not allowed in the input. Please remove all negative numbers and try again. {string.Join(", ", negativeNumbers)}");
            }
            
            return numbers.Sum();
        }

        private static int GetNumberFromString(string numberToParse)
        {
            if (int.TryParse(numberToParse, out var number) && !IsInvalidNumber(number))
            {
                return number;
            }

            return 0;
        }

        private static bool IsInvalidNumber(int numberToValidate)
        {
            return numberToValidate > 1000;
        }

        private static bool TryParseCustomDelimiterTemplate(string input, out string delimiter)
        {
            delimiter = null!;

            // Validate the custom delimiter template structure
            if (string.IsNullOrWhiteSpace(input) || !input.StartsWith("//"))
            {
                return false;
            }

            var singleNewlineIndex = input.IndexOf('\n');
            var doubleBackslashNewlineIndex = input.IndexOf("\\n", StringComparison.Ordinal);

            if (singleNewlineIndex == -1 && doubleBackslashNewlineIndex == -1)
            {
                return false;
            }

            var newLineIndex = singleNewlineIndex != -1 ? singleNewlineIndex : doubleBackslashNewlineIndex;

            // Get the delimiter
            delimiter = input.Substring(2, newLineIndex - 2);

            // Validate
            if (string.IsNullOrEmpty(delimiter))
            {
                delimiter = null!;
                return false;
            }

            return true;
        }
    }
}