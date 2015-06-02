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

        [TestCaseSource(typeof(StringCalculatorTestCases), "AdditionOfSingleNumbers")]
        [TestCaseSource(typeof(StringCalculatorTestCases), "AdditionOfTwoNumbers")]
        [TestCaseSource(typeof(StringCalculatorTestCases), "AdditionOfMultipleNumbers")]
        public void Add_ReturnsExpectedResults(string input, int expectedOutput)
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

        public static IEnumerable<TestCaseData> AdditionOfTwoNumbers
        {
            get
            {
                yield return new TestCaseData("0,0", 0);
                yield return new TestCaseData("0,1", 1);
                yield return new TestCaseData("1,0", 1);
                yield return new TestCaseData("0,-1", -1);
                yield return new TestCaseData("-1,0", -1);
                yield return new TestCaseData("1,1", 2);
                yield return new TestCaseData("-1,-1", -2);
                yield return new TestCaseData("-1,1", 0);
                yield return new TestCaseData("1,-1", 0);
                yield return new TestCaseData("10,-1", 9);
                yield return new TestCaseData("2,1", 3);
                yield return new TestCaseData("-2,-2", -4);
                yield return new TestCaseData("8721387,-23723", 8697664);
            }
        }

        public static IEnumerable<TestCaseData> AdditionOfMultipleNumbers
        {
            get
            {
                yield return new TestCaseData("-8721387,23723,0", -8697664);
                yield return new TestCaseData("2187243,-7823478,9213", -5627022);
                yield return new TestCaseData("0,0,0,0,0,0,0,0", 0);
                yield return new TestCaseData("1,2,4,25,8,25,-9", 56);
                yield return new TestCaseData("1,-2,3,-4,5,-9,8,7,-6,-5", -2);
                yield return new TestCaseData("213,23,4342,543,546,-567,65,867,878,989,345,54,73,423,42", 8836);
            }
        }
    }
}
