using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code;
using System;

namespace MSTestProject
{
    [TestClass]
    public class BankAccountTests
    {
        private BankAccount account;

        [TestInitialize]
        public void Setup() => account = new BankAccount();

        [TestMethod]
        public void Deposit_ShouldIncreaseBalance()
        {
            account.Deposit(100);
            Assert.AreEqual(100, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_ShouldDecreaseBalance()
        {
            account.Deposit(100);
            account.Withdraw(40);
            Assert.AreEqual(60, account.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Withdraw_InsufficientFunds_ShouldThrow() => account.Withdraw(50);
    }
}
