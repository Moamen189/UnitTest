using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public interface ILog
    {
        // true if writing succeeded, false otherwise
        bool Write(string msg);
    }


    class BankAccountMock
    {
        public int Balance { get; set; }
        private readonly ILog log;

        public BankAccountMock(ILog log)
        {
            this.log = log;
        }

        public void Deposit(int amount)
        {
            if (log.Write($"User has withdrawn {amount}"))
            {
                Balance += amount;
            }
        }
    }

    [TestFixture]
    public class BankAccountTestsMock
    {
        private BankAccountMock ba;

        [Test]
        public void DepositIntegrationTest()
        {
            var log = new Mock<ILog>();
            log.Setup(x => x.Write(It.IsAny<string>())).Returns(true);
            ba = new BankAccountMock(log.Object) { Balance = 100 };

            ba.Deposit(100);
            Assert.That(ba.Balance, Is.EqualTo(200));
        }


    }
}
