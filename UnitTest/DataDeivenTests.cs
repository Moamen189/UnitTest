using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestFixture]
    public class DataDrivenTestss
    {
        private BankAccount ba;

        [SetUp]
        public void SetUp()
        {
            ba = new BankAccount(100);
        }

        [Test] 
        [TestCase(50, true, 50)]
        [TestCase(1000, false, 100)]
        public void TestMultipleWithdrawalScenarios(
          int amountToWithdraw, bool shouldSucceed, int expectedBalance)
        {
            var result = ba.WithDraw(amountToWithdraw);
            Warn.If(!result, "Failed for some reason");
            Assert.Multiple(() =>
            {
                Assert.That(expectedBalance, Is.EqualTo(ba.Balance));
            });
        }
    }

    [TestFixtureSource(typeof(BankAccountWithOverdraftTestData), "Data")]
    public class BankAccountWithOverdraftTests
    {
        private BankAccount ba;

        public BankAccountWithOverdraftTests(int startingBalance)
        {
            ba = new BankAccountWithOverdraft(startingBalance, 0);
        }

        public BankAccountWithOverdraftTests(int startingBalance, int minBalance)
        {
            ba = new BankAccountWithOverdraft(startingBalance, minBalance);
        }

        [Test]
        public void MinimumBalanceIsNonPositive()
        {
            Assert.That(ba.Balance, Is.LessThanOrEqualTo(0));
        }
    }

    public class BankAccountWithOverdraftTestData
    {
        public static IEnumerable Data
        {
            get
            {
                yield return new TestFixtureData(100);
                yield return new TestFixtureData(0, -100);
                yield return new TestFixtureData(50, -50);
            }
        }
    }
}
