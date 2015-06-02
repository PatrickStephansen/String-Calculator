using System.Collections.Generic;
using Calculators;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class StringCalculatorTests
    {
        [Test]
        public void Add_ReturnsZeroForEmptyInput()
        {
            Assert.That(StringCalculator.Add(string.Empty), Is.EqualTo(0));
        }

        [TestCaseSource(typeof (StringCalculatorTestCases), "AdditionOfSingleNumbers")]
        public void Add_ReturnsCorrectResultsForSingleNumbers(string input, int expectedOutput)
        {
            Assert.That(StringCalculator.Add(input), Is.EqualTo(expectedOutput));
        }
    }

    internal static class StringCalculatorTestCases
    {
        public static IEnumerable<TestCaseData> AdditionOfSingleNumbers
        {
            get
            {
                yield return new TestCaseData("0", 0);
                yield return new TestCaseData("1", 1);
                yield return new TestCaseData("2", 2);
                yield return new TestCaseData("9", 9);
                yield return new TestCaseData("10", 10);
                yield return new TestCaseData("2147483647", 2147483647);
                yield return new TestCaseData("-1", -1);
                yield return new TestCaseData("-2", -2);
                yield return new TestCaseData("-10", -10);
                yield return new TestCaseData("-2147483648", -2147483648);
            }
        }
    }
}
