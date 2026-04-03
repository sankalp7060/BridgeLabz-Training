using NUnit.Framework;
using Code;

namespace NUnitProject
{
    [TestFixture]
    public class StringUtilsTests
    {
        private StringUtils utils;

        [SetUp]
        public void Setup() => utils = new StringUtils();

        [Test]
        public void Reverse_ShouldReverseString() => Assert.AreEqual("olleh", utils.Reverse("hello"));

        [Test]
        public void IsPalindrome_ShouldReturnTrue() => Assert.IsTrue(utils.IsPalindrome("Madam"));

        [Test]
        public void IsPalindrome_ShouldReturnFalse() => Assert.IsFalse(utils.IsPalindrome("Hello"));

        [Test]
        public void ToUpperCase_ShouldConvertToUpper() => Assert.AreEqual("HELLO", utils.ToUpperCase("hello"));
    }
}
