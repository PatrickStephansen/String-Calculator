using Calculators;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class StringCalculatorTests
    {
        [TestCaseSource(typeof (StringCalculatorTestCases), "AdditionOfEmptyString")]
        [TestCaseSource(typeof (StringCalculatorTestCases), "AdditionOfSingleNumbers")]
        [TestCaseSource(typeof (StringCalculatorTestCases), "AdditionOfTwoNumbers")]
        [TestCaseSource(typeof (StringCalculatorTestCases), "AdditionOfMultipleNumbers")]
        [TestCaseSource(typeof (StringCalculatorTestCases), "LineBreakNumberSeparators")]
        [TestCaseSource(typeof (StringCalculatorTestCases), "CustomNumberSeparators")]
        public void Add_ReturnsExpectedResults(string input, int expectedOutput)
        {
            Assert.That(StringCalculator.Add(input), Is.EqualTo(expectedOutput));
        }
    }
}
