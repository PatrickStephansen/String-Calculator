using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculators
{
    internal class CalculatorInputs
    {
        public int[] Numbers { get; set; }
        public string[] Delimiters { get; set; }

        private const string DelimiterListStartIndicator = "//";
        private const string DelimiterListEndIndicator = "\n";
        private const string IndividualDelimiterStartIndicator = @"\[";
        private const string IndividualDelimiterEndIndicator = @"\]";
        

        public CalculatorInputs(string arguments)
        {
            var inputStrings = SeparateInputStrings(arguments);
            Delimiters = GetDelimiters(inputStrings.DelimiterList);
            Numbers =
                inputStrings.NumberList.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();

        }

        private static string[] GetDelimiters(string delimiterList)
        {
            // The delimiters are ordered in descending order of length, 
            // and strings should be split in this order, because 
            // shorter delimiters could be contained in longer ones.
            if (delimiterList.Any())
                return Regex.Matches(delimiterList,
                                     string.Format("[^{0}{1}]+",
                                                   IndividualDelimiterStartIndicator,
                                                   IndividualDelimiterEndIndicator))
                            .Cast<Match>().Select(match => match.Value)
                            .OrderByDescending(delimiter => delimiter.Length)
                            .ToArray();
            return new[] {",", "\n"};
        }

        private static InputStrings SeparateInputStrings(string arguments)
        {
            if (arguments.StartsWith(DelimiterListStartIndicator))
            {
                for (var index = 0; index < arguments.Length; index++)
                {
                    var character = arguments[index];
                    if (char.IsDigit(character))
                        return new InputStrings(arguments.Substring(DelimiterListStartIndicator.Length,
                                                                    index - DelimiterListEndIndicator.Length -
                                                                    DelimiterListStartIndicator.Length),
                                                arguments.Substring(index));
                }
                // Delimiters don't matter if there are no numbers
                return new InputStrings(string.Empty, string.Empty);
            }
            return new InputStrings(string.Empty, arguments);
        }

        private struct InputStrings
        {
            public string DelimiterList { get; private set; }
            public string NumberList { get; private set; }

            public InputStrings(string delimiterList, string numberList)
                : this()
            {
                DelimiterList = delimiterList;
                NumberList = numberList;
            }
        }
    }
}