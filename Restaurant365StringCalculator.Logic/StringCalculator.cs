using Restaurant365StringCalculator.Logic.Interfaces;
using System.Text.RegularExpressions;

namespace Restaurant365StringCalculator.Logic
{
    public class StringCalculator : IStringCalculator
    {
        private readonly string[] _newLineDelimiters = { "\\n", "\n" };
        private readonly string[] _defaultDelimiters;

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
            if (TryParseCustomDelimiterTemplate(formattedNumber, out var customDelimiter))
            { 
                delimiters.AddRange(customDelimiter!);
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

        private static bool TryParseCustomDelimiterTemplate(string input, out List<string> delimiters)
        {
            delimiters = new List<string>();

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

            // Get the delimiter section
            var delimiterSection = input.Substring(2, newLineIndex - 2);

            if (delimiterSection.StartsWith("[") && delimiterSection.EndsWith("]"))
            {
                delimiterSection = delimiterSection.Substring(1, delimiterSection.Length - 2);
                
                // Split for multiple custom delimiters
                var delimiterArray = delimiterSection.Split(new[] { "][" }, StringSplitOptions.None);

                foreach (var delimiter in delimiterArray)
                {
                    // Validate
                    if (string.IsNullOrEmpty(delimiter))
                    {
                        delimiters = null!;
                        return false;
                    }
                    delimiters.Add(delimiter);
                }
            }
            else
            {
                delimiters.Add(delimiterSection);
            }

            return true;
        }
    }
}