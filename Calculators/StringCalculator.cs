
using System;
using System.Linq;

namespace Calculators
{
    public class StringCalculator
    {
        private const string DelimiterStartIndicator = "//";
        private const string DelimiterEndIndicator = "\n";
        // Numbers higher than this are ignored
        private const int MaximumAllowedNumber = 1000;

        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers)) return 0;
            string[] delimiters;

            if (numbers.StartsWith(DelimiterStartIndicator))
            {
                var delimiterEndIndex = numbers.IndexOf(DelimiterEndIndicator);
                var delimiterLength = delimiterEndIndex - DelimiterStartIndicator.Length;
                delimiters = new[]{numbers.Substring(DelimiterStartIndicator.Length, delimiterLength)};
                numbers = numbers.Substring(delimiterEndIndex + DelimiterEndIndicator.Length);
            }
            else
            {
                delimiters = new[] {",","\n"};
            }
            var numberList = numbers.Split(delimiters, StringSplitOptions.None)
                                    .Select(int.Parse).ToArray();
            var negativeNumbers = numberList.Where(number => number < 0);
            if (negativeNumbers.Any())
            {
                throw new ArgumentException(string.Format("Negative numbers not allowed: {0}",
                                                          string.Join(", ", negativeNumbers)));
            }
            return numberList.Where(n => n <= MaximumAllowedNumber).Sum();
        }
    }
}
