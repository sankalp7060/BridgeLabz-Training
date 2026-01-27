using NUnit.Framework;
using Code;

namespace NUnitProject
{
    [TestFixture]
    public class NumberUtilsTests
    {
        private NumberUtils utils;

        [SetUp]
        public void Setup() => utils = new NumberUtils();

        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(9, false)]
        public void IsEven_ShouldReturnCorrectValue(int num, bool expected)
        {
            Assert.AreEqual(expected, utils.IsEven(num));
        }
    }
}
