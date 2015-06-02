
namespace Calculators
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers)) return 0;
            var sum = 0;
            foreach (var number in numbers.Split(','))
            {
                sum += int.Parse(number);
            }
            return sum;
        }
    }
}
