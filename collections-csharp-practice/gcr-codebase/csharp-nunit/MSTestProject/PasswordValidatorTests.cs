using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;

namespace MSTestProject
{
    [TestClass]
    public class PasswordValidatorTests
    {
        private PasswordValidator validator;

        [TestInitialize]
        public void Setup() => validator = new PasswordValidator();

        [TestMethod]
        public void ValidPassword_ShouldReturnTrue() => Assert.IsTrue(validator.IsValid("Abcdef12"));

        [TestMethod]
        public void InvalidPassword_ShouldReturnFalse() => Assert.IsFalse(validator.IsValid("abc123"));
    }
}
