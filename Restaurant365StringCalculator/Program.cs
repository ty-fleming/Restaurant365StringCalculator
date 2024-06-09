using Microsoft.Extensions.DependencyInjection;
using Restaurant365StringCalculator.Logic;
using Restaurant365StringCalculator.Logic.Interfaces;

namespace Restaurant365StringCalculator
{
    internal class Program
    {
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IStringCalculator, StringCalculator>()
                .BuildServiceProvider();

            var calculator = serviceProvider.GetService<IStringCalculator>();

            try
            {
                while (true)
                {
                    Console.Write("Enter numbers (Ctrl + C or type 'exit' to quit): ");
                    var formattedStringInput = Console.ReadLine();

                    if (!string.IsNullOrEmpty(formattedStringInput))
                    {
                        if (string.Equals(formattedStringInput, "exit", StringComparison.OrdinalIgnoreCase) ||
                            calculator == null)
                        {
                            break;
                        }

                        var result = calculator.Add(formattedStringInput);
                        Console.WriteLine($"Result: {result}");
                    }
                    else
                    {
                        Console.WriteLine($"Your entry can not be null or empty");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

        }
    }
}