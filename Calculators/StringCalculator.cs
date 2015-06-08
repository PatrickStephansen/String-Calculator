
using System;
using System.Linq;

namespace Calculators
{
    public class StringCalculator
    {
        // Numbers higher than this are ignored
        private const int MaximumAllowedNumber = 1000;

        public static int Add(string numbers)
        {
            var parsedArguments = new CalculatorInputs(numbers);
            var negativeNumbers = parsedArguments.Numbers.Where(number => number < 0).ToArray();
            if (negativeNumbers.Any())
            {
                throw new ArgumentException(string.Format("Negative numbers not allowed: {0}",
                                                          string.Join(", ", negativeNumbers)));
            }
            return parsedArguments.Numbers.Where(n => n <= MaximumAllowedNumber).Sum();
            
        }
    }
}
