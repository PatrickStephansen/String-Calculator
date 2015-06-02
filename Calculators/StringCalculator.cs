
using System.Linq;

namespace Calculators
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers)) return 0;
            return numbers.Split(',','\n').Sum(number => int.Parse(number));
        }
    }
}
