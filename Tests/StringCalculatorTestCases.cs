using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    internal static class StringCalculatorTestCases
    {
        public static IEnumerable<TestCaseData> AdditionOfEmptyString
        {
            get { yield return new TestCaseData(string.Empty, 0); }
        }
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
            }
        }

        public static IEnumerable<TestCaseData> AdditionOfTwoNumbers
        {
            get
            {
                yield return new TestCaseData("0,0", 0);
                yield return new TestCaseData("0,1", 1);
                yield return new TestCaseData("1,0", 1);
                yield return new TestCaseData("1,1", 2);
                yield return new TestCaseData("9,1", 10);
                yield return new TestCaseData("2,1", 3);
                yield return new TestCaseData("8721387,23723", 8745110);
            }
        }

        public static IEnumerable<TestCaseData> AdditionOfMultipleNumbers
        {
            get
            {
                yield return new TestCaseData("8721387,23723,0", 8745110);
                yield return new TestCaseData("0,0,0,0,0,0,0,0", 0);
                yield return new TestCaseData("1,2,4,25,8,25,9", 74);
                yield return new TestCaseData("213,23,4342,543,546,567,65,867,878,989,345,54,73,423,42", 9970);
            }
        }

        public static IEnumerable<TestCaseData> LineBreakNumberSeparators
        {
            get
            {
                yield return new TestCaseData("0,0\n0,0,0,0,0,0", 0);
                yield return new TestCaseData("1,2,4,25,8\n25,9", 74);
                yield return new TestCaseData("2187243\n7823478\n9213", 10019934);
            }
        }

        public static IEnumerable<TestCaseData> CustomNumberSeparators
        {
            get
            {
                yield return new TestCaseData("//;\n1;2", 3);
                yield return new TestCaseData("//-\n1-2-4", 7);
                yield return new TestCaseData("//::\n43::6::78", 127);
                yield return new TestCaseData("//<=>\n43<=>6<=>78<=>98", 225);
            }
        }

        public static IEnumerable<TestCaseData> NegativeNumbers
        {
            get
            {
                var exceptionType = typeof (ArgumentException);
                yield return new TestCaseData("//{\n12{18{-9", exceptionType, "-9");
                yield return new TestCaseData("1,-2,3\n-4,5,-9,8\n7,-6,-5", exceptionType, "-2, -4, -9, -6, -5");
                yield return new TestCaseData("-2,-2", exceptionType, "-2, -2");
                yield return new TestCaseData("-2147483648", exceptionType, "-2147483648");
                yield return new TestCaseData("2187243,-7823478,9213", exceptionType, "-7823478");
            }
        }
    }
}