using NUnit.Framework;
using Code;
using System;

namespace NUnitProject
{
    [TestFixture]
    public class UserRegistrationTests
    {
        private UserRegistration userReg;

        [SetUp]
        public void Setup() => userReg = new UserRegistration();

        [Test]
        public void RegisterUser_ValidInput_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => userReg.RegisterUser("JohnDoe", "john@example.com", "password123"));
        }

        [Test]
        public void RegisterUser_InvalidEmail_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => userReg.RegisterUser("JohnDoe", "invalidemail", "password123"));
        }

        [Test]
        public void RegisterUser_ShortPassword_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => userReg.RegisterUser("JohnDoe", "john@example.com", "123"));
        }
    }
}
