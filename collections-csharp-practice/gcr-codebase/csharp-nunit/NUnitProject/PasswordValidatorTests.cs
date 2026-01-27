using NUnit.Framework;
using Code;

namespace NUnitProject
{
    [TestFixture]
    public class PasswordValidatorTests
    {
        private PasswordValidator validator;

        [SetUp]
        public void Setup() => validator = new PasswordValidator();

        [Test]
        public void ValidPassword_ShouldReturnTrue() => Assert.IsTrue(validator.IsValid("Abcdef12"));

        [Test]
        public void InvalidPassword_ShouldReturnFalse() => Assert.IsFalse(validator.IsValid("abc123"));
    }
}
