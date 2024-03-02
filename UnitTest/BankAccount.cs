using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            if (amount <=0)
            {
                throw new ArgumentException("Deposite Must Be Possitve Number", nameof(amount));
            }
            Balance += amount;
        }
        public bool WithDraw(int amount)
        {
            if(Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }


    }
    [TestFixture]
    public class DataDrivenTests
    {
        private BankAccount ba;

        [SetUp]
        public void SetUp()
        {
            ba = new BankAccount(100);
        }
        [Test]
        [TestCase(50 , true , 50)]
        [TestCase(100 , true , 0)]
        [TestCase(1000 , false , 100)]
        public void testWithMultipleWithDrawalSenarios(int amountToWithDrawal , bool ShouldSucceed , int expectedBalance)
        {
            var result = ba.WithDraw(amountToWithDrawal);
            // Warn.If(!result, "Failed For Some Reason");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(ShouldSucceed));
                Assert.That(expectedBalance, Is.EqualTo(ba.Balance));
            });
        }
    }
    [TestFixture]
    public class BankAccountTests
    {
      // dynamic Ba = null;
       [SetUp]
        public void SetUp()
        {
            //arrange 
           var BankAcc = new BankAccount(100);
        }
        [Test]
        public void BankAccountShouldIncreaseOnPositiveDeposit()
        {
            Assert.That(2 + 2, Is.EqualTo(2));

            //AAA
            var Ba = new BankAccount(100);

            //act 

            Ba.Depposit(100);

           //assert

            Assert.That(Ba.Balance, Is.EqualTo(100));
        }

        [Test]

        public void BankAccountShouldThrownPositiveAmount()
        {
            var Bank = new BankAccount(100);
          var ex =  Assert.Throws<ArgumentException>(() => Bank.Depposit(-1));
            StringAssert.StartsWith("Deposite Must Be Possitve Number", ex.Message);
        }

        public void MehodToTest()
        {
            var Bank = new BankAccount(100);
            Bank.WithDraw(100);
            Assert.Multiple(() =>
            {
                Assert.That(Bank.Balance, Is.EqualTo(10));
                Assert.That(Bank.Balance, Is.EqualTo(60));
                Assert.That(Bank.Balance, Is.EqualTo(1000));
            });


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

            Warn.Unless(2 + 2 == 6);
            Warn.Unless(2 + 2, Is.Not.EqualTo(6));
            Warn.Unless(() => 2 + 2, Is.Not.EqualTo(6).After(2000));
        }
    }
}
