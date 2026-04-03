using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;
using System;

namespace MSTestProject
{
    [TestClass]
    public class UserRegistrationTests
    {
        private UserRegistration userReg;

        [TestInitialize]
        public void Setup() => userReg = new UserRegistration();

        [TestMethod]
        public void RegisterUser_ValidInput_ShouldNotThrow()
        {
            userReg.RegisterUser("JohnDoe", "john@example.com", "password123");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_InvalidEmail_ShouldThrow() => userReg.RegisterUser("JohnDoe", "invalidemail", "password123");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_ShortPassword_ShouldThrow() => userReg.RegisterUser("JohnDoe", "john@example.com", "123");
    }
}
