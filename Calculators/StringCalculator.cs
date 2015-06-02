
using System.Linq;

namespace Calculators
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers)) return 0;
            if (numbers.StartsWith("//"))
            {
                var delimiter = numbers.Skip(2).First();
                return numbers.Substring(4).Split(delimiter).Sum(number => int.Parse(number));
            }
            return numbers.Split(',','\n').Sum(number => int.Parse(number));
        }
    }
}
