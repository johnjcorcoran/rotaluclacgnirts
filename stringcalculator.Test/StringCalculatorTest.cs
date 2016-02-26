using NUnit.Framework;

namespace Stringcalculator.Test
{
    public class StringCalculatorTest
    {
        [TestFixture]
        public class TheAddMethodShould
        {
            private ScClass _scClass;

            [SetUp]
            public void CreateCalculator()
            {
                _scClass = new ScClass();
            }

            [Test]
            public void Return0WhenGivenAnEmptyString()
            {
                Assert.That(_scClass.Add(string.Empty), Is.EqualTo(0));
            }

            [TestCase("1", 1)]
            [TestCase("1,2", 3)]
            [TestCase("1,2,3,4", 10)]
            public void SumCommaSeparatedNumbers(string csv, int sum)
            {
                Assert.That(_scClass.Add(csv), Is.EqualTo(sum));
            }

            [Test]
            public void SumNumbersSeparatedByNewLines()
            {
                Assert.That(_scClass.Add("1\n2,3"), Is.EqualTo(6));
            }

            [Test]
            public void SumNumbersSeparatedByCustomDelimiter()
            {
                Assert.That(_scClass.Add("//;\n1;2"), Is.EqualTo(3));
            }

            [Test]
            public void ReportIfAnyNegativeNumbersAreInTheCsv()
            {
                Assert.That(() => _scClass.Add("1,-2,-4"),
                    Throws.ArgumentException.With.Message.EqualTo("negatives not allowed: -2, -4"));
            }
        }
    }
}