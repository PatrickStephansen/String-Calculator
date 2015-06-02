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
    }
}
