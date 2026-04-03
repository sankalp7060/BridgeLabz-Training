using NUnit.Framework;
using Code;
using System;

namespace NUnitProject
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void Setup() => account = new BankAccount();

        [Test]
        public void Deposit_ShouldIncreaseBalance()
        {
            account.Deposit(100);
            Assert.AreEqual(100, account.GetBalance());
        }

        [Test]
        public void Withdraw_ShouldDecreaseBalance()
        {
            account.Deposit(100);
            account.Withdraw(40);
            Assert.AreEqual(60, account.GetBalance());
        }

        [Test]
        public void Withdraw_InsufficientFunds_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(50));
        }
    }
}
