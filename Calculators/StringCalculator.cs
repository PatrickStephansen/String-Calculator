
using System;
using System.Linq;

namespace Calculators
{
    public class StringCalculator
    {
        private const string DelimiterStartIndicator = "//";
        private const string DelimiterEndIndicator = "\n";

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
            return numbers.Split(delimiters, StringSplitOptions.None)
                          .Sum(number => int.Parse(number));
        }
    }
}
