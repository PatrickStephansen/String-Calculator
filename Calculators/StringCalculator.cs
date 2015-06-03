
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculators
{
    public class StringCalculator
    {
        private const string DelimiterListStartIndicator = "//";
        private const string DelimiterListEndIndicator = "\n";
        // Numbers higher than this are ignored
        private const int MaximumAllowedNumber = 1000;

        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers)) return 0;
            string[] delimiters;

            if (numbers.StartsWith(DelimiterListStartIndicator))
            {
                var delimiterEndIndex = numbers.IndexOf(DelimiterListEndIndicator);
                var delimiterLength = delimiterEndIndex - DelimiterListStartIndicator.Length;
                delimiters = GetDelimiters(numbers.Substring(DelimiterListStartIndicator.Length, delimiterLength));
                numbers = numbers.Substring(delimiterEndIndex + DelimiterListEndIndicator.Length);
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

        private static string[] GetDelimiters(string delimiterList)
        {
            // Each delimiter is enclosed in square brackets.
            // The delimiters are ordered in descending order of length, 
            // and strings should be split in this order, because 
            // shorter delimiters could be contained in longer ones.
            return Regex.Matches(delimiterList, @"[^\[\]]+")
                        .Cast<Match>().Select(match => match.Value)
                        .OrderByDescending(delimiter => delimiter.Length).ToArray();
        }
    }
}
