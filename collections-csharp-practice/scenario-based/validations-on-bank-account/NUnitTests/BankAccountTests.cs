using System;
using BankApp;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            var account = new BankAccount(100);
            account.Deposit(50);

            Assert.That(account.Balance, Is.EqualTo(150));
        }

        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            var account = new BankAccount(100);

            var ex = Assert.Throws<ArgumentException>(() => account.Deposit(-20));

            Assert.That(ex.Message, Is.EqualTo("Deposit amount cannot be negative"));
        }

        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            var account = new BankAccount(200);
            account.Withdraw(50);

            Assert.That(account.Balance, Is.EqualTo(150));
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            var account = new BankAccount(100);

            var ex = Assert.Throws<InvalidOperationException>(() => account.Withdraw(200));

            Assert.That(ex.Message, Is.EqualTo("Insufficient funds."));
        }
    }
}
