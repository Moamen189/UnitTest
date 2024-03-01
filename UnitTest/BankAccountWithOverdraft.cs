namespace UnitTest
{
    internal class BankAccountWithOverdraft : BankAccount
    {
        private int startingBalance;
        private int minBalance;

        public BankAccountWithOverdraft(int startingBalance, int minBalance) : base(startingBalance)
        {
            this.startingBalance = startingBalance;
            this.minBalance = minBalance;
        }
    }
}