namespace Group_Project_for_Programming_2
{
    class SavingAccount : Account, ITransaction
    {
        private static double COST_PER_TRANSACTION = 0.05;
        private static double INTEREST_RATE = 0.005;
        private bool hasOverdraft;

        public SavingAccount(double balance = 0, bool hasOverdraft = false)
            : base("SV-", balance)
        {
            this.hasOverdraft = hasOverdraft;
        }

        public new void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, true));
        }

        public void Withdraw(double amount, Person person)
        {
            if (!IsAssociatedWithAccount(person))
            {
                OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }

            if (!IsLoggedIn(person))
            {
                OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(ExceptionType.USER_NOT_LOGGED_IN);
            }

            if (amount > Balance && !hasOverdraft)
            {
                OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
                throw new AccountException(ExceptionType.NO_OVERDRAFT);
            }

            base.Deposit(-amount, person);
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, true));
        }

        public override void PrepareMonthlyReport()
        {
            double serviceCharge = transactions.Count * COST_PER_TRANSACTION;
            double interest = LowestBalance * INTEREST_RATE / 12;
            Balance += interest - serviceCharge;
            transactions.Clear();
        }

        private bool IsAssociatedWithAccount(Person person)
        {
                // Check if the person is associated with this account
                // You can implement the logic here based on your requirements
            return true;
        }
    private bool IsLoggedIn(Person person)
        {
            // Check if the person is logged in
            // You can implement the logic here based on your requirements
            return true;
        }
    }
}
