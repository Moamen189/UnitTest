using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class BankAccount
    {
        public int Balance { get; private set; }

        public BankAccount(int balance)
        {
            Balance = balance;
        }
        public void Depposit(int amount)
        {
        
        }
        public void WithDraw(int amount)
        {
           
        }


    }

    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void BankAccountShouldIncreaseOnPositiveDeposit()
        {
            Assert.Fail("this Must Fail");
        }


    }
    [TestFixture]
    public class MyFixtures
    {
        [Test]
        public void Warnings()
        {
            Warn.If(2 + 2 != 6);
            Warn.If(2 + 2 , Is.Not.EqualTo(6));
            Warn.If(() => 2 + 2 , Is.Not.EqualTo(6).After(2000));
        }
    }
}
